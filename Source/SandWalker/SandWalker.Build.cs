// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class SandWalker : ModuleRules
{
	public SandWalker(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"SandWalker",
			"SandWalker/Variant_Platforming",
			"SandWalker/Variant_Platforming/Animation",
			"SandWalker/Variant_Combat",
			"SandWalker/Variant_Combat/AI",
			"SandWalker/Variant_Combat/Animation",
			"SandWalker/Variant_Combat/Gameplay",
			"SandWalker/Variant_Combat/Interfaces",
			"SandWalker/Variant_Combat/UI",
			"SandWalker/Variant_SideScrolling",
			"SandWalker/Variant_SideScrolling/AI",
			"SandWalker/Variant_SideScrolling/Gameplay",
			"SandWalker/Variant_SideScrolling/Interfaces",
			"SandWalker/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
