using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Burnout.Helpers
{
    public class PresetHelper
    {
        public struct TrailPreset
        {
            public static Dictionary<string, TrailPreset> ConfigDict = new Dictionary<string, TrailPreset>()
            { 
                {"Default", new TrailPreset(0.5f, 1.0f, 1.0f, false, ColorHelper.Default_Red, ColorHelper.Default_Blue)},
                {"Classic", new TrailPreset(0.5f, 1.0f, 1.0f, true, Color.red, Color.red)},
                {"Mono-Blue", new TrailPreset(0.5f, 1.0f, 1.0f, true, ColorHelper.Default_Blue, ColorHelper.Default_Blue)}
            };

            public TrailPreset(float duration, float intensity, float size, bool overridecols, Color col_l, Color col_r)
            {
                Duration = duration;
                Intensity = intensity;
                Size = size;
                LeftColor = col_l;
                RightColor = col_r;
                OverrideColors = overridecols;
            }

            public float Duration;
            public float Intensity;
            public float Size;
            public bool OverrideColors;
            public Color LeftColor;
            public Color RightColor;
        };

        public static void ApplyPreset(TrailPreset preset)
        {
            var config = Settings.instance;
            config.BurnLifespan = preset.Duration;
            config.BurnOpacity = preset.Intensity;
            config.BurnScale = preset.Size;
            config.OverrideColors = preset.OverrideColors;
            config.Color_LSaber = ColorHelper.ColorToHex(preset.LeftColor);
            config.Color_RSaber = ColorHelper.ColorToHex(preset.RightColor);
        }
    }
}
