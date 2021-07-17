using BeatSaberMarkupLanguage;
using BS_Utils.Utilities;
using Burnout.Helpers;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace Burnout.HarmonyPatches
{
    [HarmonyAfter("Chroma")]
    [HarmonyPatch(typeof(SaberBurnMarkArea), "Start")]
    internal class SaberBurnMarkArea_Start
    {
        internal static void Prefix(SaberBurnMarkArea __instance)
        {
            if (Settings.instance.BurnLifespan == 0f)
            {
                __instance.enabled = false;
            }
        }
        internal static void Postfix(SaberBurnMarkArea __instance)
        {
            var config = Settings.instance;
            float clampedOpacity = Math.Max(0.4f, config.BurnOpacity);

            __instance.SetField("_burnMarksFadeOutStrength", (5.0f / clampedOpacity) * config.BurnLifespan);

            LineRenderer[] burnRenderers = __instance.GetField<LineRenderer[]>("_lineRenderers");
            for (int i = 0; i < burnRenderers.Length; i++)
            {
                LineRenderer renderer = burnRenderers[i];
                Color burnColor = renderer.startColor;

                if (config.OverrideColors)
                {
                    if (i == 0) burnColor = ColorHelper.HexToColor(config.Color_LSaber);
                    else burnColor = ColorHelper.HexToColor(config.Color_RSaber);
                }

                burnColor.a = clampedOpacity;
                renderer.startColor = burnColor;
                renderer.endColor = burnColor;
            }
        }
    }

}