// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;
using System;
public class ue4_fade2d_test : ModuleRules
{
    public string GetUProjectPath()
    {
        return Path.Combine(ModuleDirectory, "../../");
    }
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../fade2d/")); }
    }
    private string CopyToProjectBinaries(string Filepath, ReadOnlyTargetRules Target)
    {
        string BinariesDir = Path.Combine(GetUProjectPath(), "Binaries", Target.Platform.ToString());
        string Filename = Path.GetFileName(Filepath);
        //convert relative path
        string FullBinariesDir = Path.GetFullPath(BinariesDir);
        if (!Directory.Exists(FullBinariesDir))
        {
            Directory.CreateDirectory(FullBinariesDir);
        }
        string FullExistingPath = Path.Combine(FullBinariesDir, Filename);
        bool ValidFile = false;
        //File exists, check if they're the same
        if (File.Exists(FullExistingPath))
        {
            ValidFile = true;
        }
        //No valid existing file found, copy new dll
        if (!ValidFile)
        {
            File.Copy(Filepath, Path.Combine(FullBinariesDir, Filename), true);
        }
        Console.WriteLine(Path.Combine(FullBinariesDir, Filename).ToString() + "===============");
        return FullExistingPath;
    }

    public ue4_fade2d_test(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });



        PublicDefinitions.Add("WITH_MYTHIRDPARTYLIBRARY=1");
        string fadePath = Path.Combine(ThirdPartyPath);
        System.Console.WriteLine("include path: " + Path.Combine(fadePath, "include_fade2d"));
        PublicIncludePaths.AddRange(new string[] { Path.Combine(fadePath, "include_fade2d") });
        string win64 = Path.Combine(fadePath);
        PublicLibraryPaths.Add(win64); ;
         PublicAdditionalLibraries.Add(Path.Combine(win64, "fade2D_x64_v142_Release.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(win64, "libgmp-10.lib"));
         string pluginDLLPath = Path.Combine(win64, "fade2D_x64_v142_Release.dll");
        string binariesPath = CopyToProjectBinaries(pluginDLLPath, Target);
         System.Console.WriteLine("Using Python DLL: " + binariesPath);
         RuntimeDependencies.Add(binariesPath);
         pluginDLLPath = Path.Combine(win64, "libgmp-10.dll");
         binariesPath = CopyToProjectBinaries(pluginDLLPath, Target);
         RuntimeDependencies.Add(binariesPath);
 
        // Uncomment if you are using Slate UI
        // PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

        // Uncomment if you are using online features
        // PrivateDependencyModuleNames.Add("OnlineSubsystem");

        // To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
    }
}
