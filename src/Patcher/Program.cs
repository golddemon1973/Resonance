using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Resonance.Patcher
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                // Running from: dist/Patched/
                string rootDir = Path.GetFullPath(Path.Combine(baseDir, "..", ".."));

                string vanillaAsmPath = Path.Combine(rootDir, ".deps", "Vanilla", "Assembly-CSharp.dll");
                string apiAsmPath = Path.Combine(rootDir, "dist", "Output", "Resonance.dll");
                string outputAsmPath = Path.Combine(rootDir, "dist", "Output", "Assembly-CSharp.dll");

                Console.WriteLine($"[Patcher] Root:    {rootDir}");
                Console.WriteLine($"[Patcher] Vanilla: {vanillaAsmPath}");
                Console.WriteLine($"[Patcher] Resonance:     {apiAsmPath}");
                Console.WriteLine($"[Patcher] Output:  {outputAsmPath}");

                if (!File.Exists(vanillaAsmPath))
                    throw new FileNotFoundException("Vanilla assembly not found: ", vanillaAsmPath);
                if (!File.Exists(apiAsmPath))
                    throw new FileNotFoundException("Resonance assembly not found: ", apiAsmPath);

                Console.WriteLine("[Patcher] Reading assemblies...");

                var resolver = new DefaultAssemblyResolver();
                resolver.AddSearchDirectory(Path.GetDirectoryName(vanillaAsmPath));

                var gameAssembly = AssemblyDefinition.ReadAssembly(vanillaAsmPath, new ReaderParameters
                {
                    AssemblyResolver = resolver
                });
                var apiAssembly = AssemblyDefinition.ReadAssembly(apiAsmPath);

                var awakeMethod = gameAssembly.MainModule.Types.First(t => t.Name == "GameManager")
                                                                     .Methods.First(m => m.Name == "Awake");
                var initializeMethod = apiAssembly.MainModule.Types.First(t => t.FullName == "Resonance.ModLoader.Loader")
                                                                    .Methods.First(m => m.Name == "Initialize");

                Console.WriteLine("[Patcher] Patching GameManager.Awake...");
                var il = awakeMethod.Body.GetILProcessor();
                il.InsertBefore(awakeMethod.Body.Instructions.First(),
                    il.Create(OpCodes.Call, gameAssembly.MainModule.ImportReference(initializeMethod)));

                Console.WriteLine("[Patcher] Writing patched assembly...");
                gameAssembly.Write(outputAsmPath);

                Console.WriteLine("[Patcher] Done: " + outputAsmPath);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Patcher] CRITICAL FAILURE: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}