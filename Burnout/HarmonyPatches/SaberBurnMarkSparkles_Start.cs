using BeatSaberMarkupLanguage;
using BS_Utils.Utilities;
using Burnout.Helpers;
using HarmonyLib;
using System;
using UnityEngine;

namespace Burnout.HarmonyPatches
{
    [HarmonyPatch(typeof(SaberBurnMarkSparkles), "LateUpdate")]
    internal class SaberBurnMarkSparkles_Start
    {
        internal static void Postfix(SaberBurnMarkSparkles __instance)
        {
            var config = Settings.instance;
            ParticleSystem.EmitParams emitParams = __instance.GetField<ParticleSystem.EmitParams>("_sparklesEmitParams");

            for (int i = 0; i < 2; i++)
            {
                Color burnColor = emitParams.startColor;
                if (config.OverrideColors)
                {
                    if (i == 0) burnColor = ColorHelper.HexToColor(config.Color_LSaber);
                    else burnColor = ColorHelper.HexToColor(config.Color_RSaber);
                }

                emitParams.startColor = burnColor;
            }

        }
    }

}