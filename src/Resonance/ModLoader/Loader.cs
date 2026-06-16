using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Resonance.Utils;
using HarmonyLib;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Resonance.Menus;

namespace Resonance.ModLoader
{
    public static class RMCFParser
    {
        public static Dictionary<string, object> Load(string filePath)
        {
            var settings = new Dictionary<string, object>();
            if (!File.Exists(filePath)) return settings;

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string trimmed = line.Trim();
                    if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#")) continue;

                    int typeOpen = trimmed.IndexOf('(');
                    int typeClose = trimmed.IndexOf(')');
                    int braceOpen = trimmed.IndexOf('{');
                    int braceClose = trimmed.LastIndexOf('}');

                    if (typeOpen == -1 || typeClose == -1 || braceOpen == -1 || braceClose == -1 || typeClose > braceOpen)
                        continue;

                    string typeStr = trimmed.Substring(typeOpen + 1, typeClose - typeOpen - 1).Trim().ToLower();
                    string innerContent = trimmed.Substring(braceOpen + 1, braceClose - braceOpen - 1);

                    int comma = innerContent.IndexOf(',');
                    if (comma == -1) continue;

                    string key = innerContent.Substring(0, comma).Trim();
                    string valStr = innerContent.Substring(comma + 1).Trim();

                    object parsedValue = typeStr switch
                    {
                        "bool" => bool.TryParse(valStr, out bool b) ? b : false,
                        "int" => int.TryParse(valStr, out int i) ? i : 0,
                        "float" => float.TryParse(valStr, out float f) ? f : 0f,
                        _ => valStr // Defaults to string
                    };

                    settings[key] = parsedValue;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Resonance", $"Error parsing RMCF file {Path.GetFileName(filePath)}: {ex.Message}");
            }

            return settings;
        }

        public static void Save(string filePath, Dictionary<string, object> settings)
        {
            if (settings == null || settings.Count == 0) return;

            try
            {
                using var writer = new StreamWriter(filePath, false);
                foreach (var kvp in settings)
                {
                    if (kvp.Value == null) continue;

                    string typeStr = kvp.Value switch
                    {
                        bool => "bool",
                        int => "int",
                        float => "float",
                        _ => "string"
                    };

                    // Booleans must save as lowercase 'true'/'false' to match bool.TryParse expectations on load
                    string valueStr = kvp.Value is bool b ? b.ToString().ToLower() : kvp.Value.ToString();
                    writer.WriteLine($"({typeStr}) {{{kvp.Key}, {valueStr}}}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Resonance", $"Error saving RMCF file {Path.GetFileName(filePath)}: {ex.Message}");
            }
        }
    }

    public static class Loader
    {
        private static readonly List<Mod> _LoadedMods = new();
        public static IReadOnlyList<Mod> LoadedMods => _LoadedMods;

        private static Harmony HarmonyInstance;
        private static string LocalLowHkFolder;
        private static bool Initialized = false;
        public static void InitializeHarmony()
        {
            try
            {
                HarmonyInstance = new Harmony("com.resonance.api");
                HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
                Logger.Log("Resonance", "Hooks applied successfully");
            }
            catch (Exception Ex)
            {
                Logger.Error("Resonance", $"Hooks could not be applied: {Ex.ToString()}");
            }
        }

        public static void Initialize()
        {
            if (Initialized) {
                Logger.Log("Resonance.SAFEGUARD", "Attempted to initialize again");

                return;
            }

            Initialized = true;

            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string LocalLow = Path.Combine(Path.GetDirectoryName(AppData), "LocalLow");
            LocalLowHkFolder = Path.Combine(LocalLow, "Team Cherry", "Hollow Knight");

            try
            {
                InGameConsole.Initialize();
                MenuCore.Initialize();

                Logger.Log("Resonance", "Resonance initialized successfully");
            }
            catch (Exception Ex)
            {
                Logger.Error("Resonance", $"Resonance could not initialize: {Ex.ToString()}");
            }

            InitializeHarmony();

            System.Collections.Generic.Dictionary<string, System.Version> HarmonyVersionInfo = HarmonyLib.Harmony.VersionInfo(out System.Version _HarmonyVersion);
            string HarmonyVersion = _HarmonyVersion.ToString();

            Logger.Log("Resonance", $"Versions:\nGame: {GameData.version}\nHarmonyX: {HarmonyVersion}\nResonance: {Params.Version}");

            string RootDirectory = AppContext.BaseDirectory;
            string ModsFolder = Path.Combine(RootDirectory, "Mods");

            if (!Directory.Exists(ModsFolder))
            {
                Directory.CreateDirectory(ModsFolder);
                Logger.Log("Resonance", $"Created Mods folder at: {ModsFolder}");
                return;
            }

            string[] ModDirectories = Directory.GetDirectories(ModsFolder);
            List<Mod> FoundMods = new();

            foreach (string dir in ModDirectories)
            {
                string[] Files = Directory.GetFiles(dir, "*.dll");
                foreach (string dllPath in Files)
                {
                    Mod LoadedMod = LoadModAssembly(dllPath);
                    if (LoadedMod != null)
                    {
                        FoundMods.Add(LoadedMod);
                    }
                }
            }


            List<Mod> ValidatedMods = new();

            foreach (Mod ModToCheck in FoundMods)
            {
                bool DependenciesSatisfied = true;
                var Dependencies = ModToCheck.GetDependencies();

                if (Dependencies != null)
                {
                    foreach (var kvp in Dependencies)
                    {
                        string ReqName = kvp.Key;
                        string ReqVersion = kvp.Value;

                        Mod SatisfyingDependency = FoundMods.Find(m => 
                            m.GetName() == ReqName && 
                            (ReqVersion == "any" || m.GetVersion() == ReqVersion)
                        );

                        if (SatisfyingDependency == null)
                        {
                            DependenciesSatisfied = false;
                            
                            bool modExistsWithWrongVersion = FoundMods.Exists(m => m.GetName() == ReqName);
                            if (modExistsWithWrongVersion)
                            {
                                string actualVer = FoundMods.Find(m => m.GetName() == ReqName).GetVersion();
                                Logger.Error(ModToCheck.GetName(), $"Requires '{ReqName}' version '{ReqVersion}' but found version '{actualVer}'");
                            }
                            else
                            {
                                Logger.Error(ModToCheck.GetName(), $"Requires '{ReqName}' {(ReqVersion == "any" ? "" : $"version '{ReqVersion}' ")}but it could not be found");
                            }
                            break;
                        }
                    }
                }

                if (DependenciesSatisfied)
                {
                    ValidatedMods.Add(ModToCheck);
                }
            }

            List<Mod> SortedMods = new();
            HashSet<string> Visiting = new();
            HashSet<string> Visited = new();

            bool SortHasErrors = false;

            void Visit(Mod mod)
            {
                if (SortHasErrors) return;
                if (Visited.Contains(mod.GetName())) return;

                if (Visiting.Contains(mod.GetName()))
                {
                    Logger.Error("Resonance", $"Found cyclic dependency involving mod: {mod.GetName()}");
                    SortHasErrors = true;
                    return;
                }

                Visiting.Add(mod.GetName());

                var deps = mod.GetDependencies();
                if (deps != null)
                {
                    foreach (var kvp in deps)
                    {
                        Mod dependencyMod = ValidatedMods.Find(m => m.GetName() == kvp.Key);
                        if (dependencyMod != null)
                        {
                            Visit(dependencyMod);
                        }
                    }
                }

                Visiting.Remove(mod.GetName());
                Visited.Add(mod.GetName());
                SortedMods.Add(mod);
            }

            foreach (Mod mod in ValidatedMods)
            {
                Visit(mod);
            }

            if (SortHasErrors)
            {
                SortedMods = new List<Mod>(ValidatedMods);
                SortedMods.Sort((a, b) => a.GetPriority().CompareTo(b.GetPriority()));
            }

            Logger.Log("Resonance", $"Found {SortedMods.Count} mods");

            if (SortedMods.Count > 0)
            {
                Logger.Log("Resonance", "Loading mods...");
                foreach (Mod CurrentMod in SortedMods)
                {
                    try
                    {
                        string configPath = Path.Combine(LocalLowHkFolder, $"{CurrentMod.GetName()}.rmcf");
                        Dictionary<string, object> loadedSettings = RMCFParser.Load(configPath);

                        CurrentMod.Load(loadedSettings);
                        _LoadedMods.Add(CurrentMod);
                        Logger.Log("Resonance", $"Loaded: {CurrentMod.GetName()} [v{CurrentMod.GetVersion()}]");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(CurrentMod.GetName(), $"Load failed: {ex.Message}");
                    }
                }
                Logger.Log("Resonance", "Loaded mods");
            }
            else
            {
                Logger.Log("Resonance", "No mods to load, skipping");
            }
        }

        public static void HandleGameQuit()
        {
            Logger.Log("Resonance", "Saving mod profiles...");

            foreach (Mod CurrentMod in _LoadedMods)
            {
                try
                {
                    var settingsToSave = CurrentMod.Quit();

                    string configPath = Path.Combine(LocalLowHkFolder, $"{CurrentMod.GetName()}.rmcf");
                    RMCFParser.Save(configPath, settingsToSave);
                }
                catch (Exception ex)
                {
                    Logger.Error(CurrentMod.GetName(), $"Failed to cleanly save configurations on quit: {ex.Message}");
                }
            }

            Logger.Log("Resonance", "All mod profiles saved");

            Logger.FlushToDisk();
        }

        private static Mod LoadModAssembly(string pathStr)
        {
            try
            {
                Assembly AssemblyObj = Assembly.LoadFrom(pathStr);
                foreach (Type TypeObj in AssemblyObj.GetTypes())
                {
                    if (!TypeObj.IsInterface && !TypeObj.IsAbstract && typeof(Mod).IsAssignableFrom(TypeObj))
                    {
                        if (Activator.CreateInstance(TypeObj) is Mod ModInstance)
                            return ModInstance;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Resonance", $"Failed to parse assembly {Path.GetFileName(pathStr)}: {ex.Message}");
            }
            return null;
        }

        [ThreadStatic]
        private static bool _isResolving;

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (_isResolving) return null;

            _isResolving = true;
            try
            {
                string asmName = new AssemblyName(args.Name).Name;

                if (asmName == "Resonance") return Assembly.GetExecutingAssembly();

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.GetName().Name == asmName)
                        return assembly;
                }

                string path = Path.Combine(LocalLowHkFolder, "Mods", asmName + ".dll");
                if (File.Exists(path))
                {
                    return Assembly.Load(File.ReadAllBytes(path));
                }
            }
            finally
            {
                _isResolving = false;
            }

            return null;
        }
    }
}