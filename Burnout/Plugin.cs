using Burnout.Helpers;
using HarmonyLib;
using IPA;
using IPA.Config;
using System;
using System.IO;
using IPALogger = IPA.Logging.Logger;

namespace Burnout
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public const string assemblyName = "Burnout";
        static Harmony harmPatcher;

        [Init]
        public Plugin(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            Logger.log = logger;
        }

        [OnEnable]
        public void Enable()
        {
            PersistentSingleton<Settings>.TouchInstance();
            PersistentSingleton<UISingleton>.TouchInstance();
            UISingleton.RegMenuButton();
            ApplyPatches();
        }

        public static void ApplyPatches() 
        {
            if (Settings.instance.EnableTweaks && harmPatcher == null)
            {
                harmPatcher = new Harmony(assemblyName);
                harmPatcher.PatchAll();
            }
        }

        [OnDisable]
        public static void Disable()
        {
            harmPatcher.UnpatchAll(assemblyName);
            harmPatcher = null;
        }

    }
}