# 𝑅𝑒𝓈𝑜𝓃𝒶𝓃𝒸𝑒

Resonance is a lightweight, beginner friendly and multi-purpose API used to mod Hollow Knight.

<img width="1024" height="1024" alt="logo" src="https://github.com/user-attachments/assets/df791dc8-0e6b-4815-89ab-6ae06dd6bf2f" />

[![Releases](https://img.shields.io/badge/Resonance-PRC1_square?style=flat-square&color=blue)](https://github.com/golddemon1973/Resonance/releases)
[![HarmonyX](https://img.shields.io/badge/HarmonyX-2.16.1-blueviolet?style=flat-square)](https://github.com/bepInEx/HarmonyX)

> [!WARNING]
> Resonance is still in **very early development stages**; Hollow Knight may be unstable, often crash or have issues even with the latest releases that Resonance has been built for.

## Installation

> [!NOTE]
> If you make a mistake here, doing a simple fresh reinstall of your game and redoing it will usually fix it.

To install this API to your Hollow Knight installation, here are the steps to follow:
1. Get a **fresh** install of Hollow Knight
2. Get the files from Resonance's [releases](https://github.com/golddemon1973/Resonance/releases)
3. Move over to your Hollow Knight installation

On **Steam**, you can go to your game, click the gear icon and go to Manage > Browse Local Files; then, go to Hollow Knight_Data > Managed and copy and replace every single file
On **Xbox**, you can go to your game, click the three dots, click Manage > Files > Browse...; then, go to Hollow Knight_Data > Managed and copy and replace every single file
On **GOG**, you can go to your game, click the button with two bars and two dots, click Manage Installation > Show Folder; then, go to Hollow Knight_Data > Managed and copy and replace every single file
If you are using a pirated/cracked version, support will not be provided

## Installing Mods

For now, Resonance does not have a dedicated installer, as installers like Lumafly and Scarab would force install the wrong files on your Hollow Knight installation and would place mods in the wrong folder.
However, you can search up the mods you want for their GitHub, and download the .zip file from the latest releases. Then create a new folder inside your Hollow Knight > Mods folder, copy the files there and you'll be done.

## Making Mods

To make mods, you will need sufficient knowledge of C# and .NET.

### Install

> [!IMPORTANT]
> You must already have Resonance installed, steps explained in **Installation**

Install .NET Standard 2.1:

**On Windows:**

```powershell
&powershell -NoProfile -ExecutionPolicy unrestricted -Command "&([scriptblock]::Create((Invoke-WebRequest -UseBasicParsing 'https://dot.net/v1/dotnet-install.ps1'))) -Channel 8.0"
```

**On Linux:**

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0
```

### Setup

Create a new directory wherever you want, and run this to make a template:

```powershell
dotnet new console
```

Then, change the .csproj to this:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>disable</Nullable>
    <ImplicitUsings>disable</ImplicitUsings>
    <AssemblyName>ResonanceMod</AssemblyName>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>

    <HKManagedPath>D:\Games\Hollow Knight\Hollow Knight_Data\Managed</HKManagedPath>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="Resonance">
      <HintPath>$(HKManagedPath)\Resonance.dll</HintPath>
      <Private>false</Private>
    </Reference>

    <Reference Include="Assembly-CSharp">
      <HintPath>$(HKManagedPath)\Assembly-CSharp.dll</HintPath>
      <Private>false</Private>
    </Reference>
	  
    <Reference Include="UnityEngine.CoreModule">
      <HintPath>$(HKManagedPath)\UnityEngine.CoreModule.dll</HintPath>
      <Private>false</Private>
    </Reference>
    
    <Reference Include="UnityEngine.UIModule">
      <HintPath>$(HKManagedPath)\UnityEngine.UIModule.dll</HintPath>
      <Private>false</Private>
    </Reference>
  </ItemGroup>
</Project>
```
Change HKManagedPath to the path to your Hollow Knight Managed directory! You can also change AssemblyName to your liking.

Now, let's setup your mod:

1. Rename Program.cs to Mod.cs for clarity
2. Change Mod.cs to this:
```csharp
using Resonance.Utils;
using Resonance.ModLoader;
using System.Collections.Generic;
using Hooks = Resonance.Hooks;
using Logger = Resonance.Utils.Logger;

namespace ResonanceMod
{
    public class ResonanceMod : Mod
    {
        public string GetName() => "ResonanceMod"; // This is your mod's name
        public string GetVersion() => "1.0.0"; // This is your mod's version
        public string GetDescription() => "A brand new mod for Resonance."; // This is your mod's description
        public int GetPriority() => 2; // This is your mod's priority, the higher it is, the later it will be loaded

        // This is your mod's dependencies
        // This allows Resonance to know whether or not your mod has the required dependencies, and if not block loading
        // for easier fixing for beginners
        // You do, for example:
        // ["SomeLibraryMod"] = "0.5.2",
        // Or, if you don't need a specific version:
        // ["SomeLibraryMod"] = "any",
        public Dictionary<string, string> GetDependencies() => new()
        {
        };

        // This is the method that is called whenever your mod loads, provided with some hooks and how to load settings
        public void Load(Dictionary<string, object> LoadedSave)
        {
            LoadedSave.TryGetValue("IsCool", out object Value);

            if (Value != null)
            {
                Logger.Log(this, Value.ToString());
            }

            Logger.Log(this, "Mod loaded successfully!");

            Hooks.EnemyHooks.OnSlashHitEnemy += OnPlayerHitEnemy;
            Hooks.EnemyHooks.OnSpellHitEnemy += OnPlayerHitEnemy;
            Hooks.EnemyHooks.OnSharpShadowHitEnemy += OnPlayerHitEnemy;
        }

        // This method is currently unused! In later Resonance versions, it will be used.
        public void Enabled()
        {
            Logger.Log(this, "Mod enabled.");
        }

        // This method is currently unused! In later Resonance versions, it will be used.
        public void Disabled()
        {
            Logger.Log(this, "Mod disabled.");
        }

        // This is the method that is called whenever the game quits, you must return a dictionary containing your mod's settings, or return an empty dictionary if you don't need to (this will be simplified in later versions)
        public Dictionary<string, object> Quit()
        {
            // Cleanup on game exit

            return new Dictionary<string, object>
            {
                ["IsCool"] = true,
            };
        }

        // This is a method used for a hook
        public void OnPlayerHitEnemy (HealthManager hm, HitInstance hit)
        {
            Logger.Log(this, "Hit enemy!!!");

            HeroController.instance.AddHealth(1);
        }
    }
}
```
3. Use Visual Studio to build it, or simply run this command in your mod's directory:

```powershell
dotnet build
```

4. Copy the .dll files in your bin directory
5. Go to your Hollow Knight Folder > Mods, creates a new folder with the name of your mod and copy the .dll files there
6. Enjoy!

### Hey Niko, let's go modding!

Now that you're done with the Installation and the Setup, you have all the chances to become a great modder.
If you ever feel stuck, you can always ask for help on the Discord server below!

[![Discord](https://img.shields.io/badge/Discord-%235865F2.svg?style=flat-square&logo=discord&logoColor=white)](https://discord.gg/DBHVUceW3Y)

