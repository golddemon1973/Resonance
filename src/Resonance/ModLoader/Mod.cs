using System;
using System.Collections.Generic;

namespace Resonance.ModLoader
{
    public interface Mod
    {
        // Info

        /// <summary>
        /// Gets the mod's name, later displayed in the Mods menu and used for GetDependencies.
        /// </summary>
        /// <returns></returns>
        string GetName() => "PlaceholderName";

        /// <summary>
        /// Gets the mod's version, later displayed in the Mods menu and used for GetDependencies.
        /// </summary>
        /// <returns>String representing the version</returns>
        string GetVersion() => "0.0.0";

        /// <summary>
        /// Gets the mod's description, later displayed in the Mods menu.
        /// </summary>
        /// <returns>String representing the description</returns>
        string GetDescription() => "No description.";

        /// <summary>
        /// Mod's priority; loads mods depending on their priority, mods with priority 1 first, and then the others depending on their priority.
        /// </summary>
        /// <returns>An int representing the priority</returns>
        int GetPriority() => 2;

        /// <summary>
        /// Dictionary containing all dependencies and their versions.
        /// If the required dependency(ies) with its/their required version(s) is/are not present, the mod will not load.
        /// </summary>
        /// <returns>A dictionary containing the mod's name and its needed version</returns>
        Dictionary<string, string> GetDependencies() => NoDependencies;

        private static readonly Dictionary<string, string> NoDependencies = new();

        // Functions

        /// <summary>
        /// Function that gets called upon loading mods
        /// </summary>
        void Load(Dictionary<string, object> LoadedSettings);

        /// <summary>
        /// Function that gets called whenever the mod gets enabled
        /// </summary>
        void Enabled();

        /// <summary>
        /// Function that gets called whenever the mod is disabled
        /// </summary>
        void Disabled();

        /// <summary>
        /// Function that gets called whenever the game quits
        /// </summary>
        Dictionary<string, object> Quit();


    }
}