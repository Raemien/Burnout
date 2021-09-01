using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using UnityEngine;
using Burnout.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Burnout
{
    class BurnMainSettings : BSMLResourceViewController
    {
        public override string ResourceName => "Burnout.Views.MainMenu.bsml";

        internal bool _EnableTweaks = Settings.instance.EnableTweaks;
        internal bool _OverrideColors = Settings.instance.OverrideColors;
        internal Color _LeftColor = ColorHelper.HexToColor(Settings.instance.Color_LSaber);
        internal Color _RightColor = ColorHelper.HexToColor(Settings.instance.Color_RSaber);

        [UIObject("color-container")]
        internal GameObject ColorContainer;

        [UIValue("preset-options")]
        private List<object> BurnPresets = new object[] { "Custom", "Default", "Classic", "Mono-Blue" }.ToList();

        [UIValue("master-enabled")]
        internal bool EnableTweaks
        {
            get => _EnableTweaks;
            set => _EnableTweaks = value;
        }

        [UIValue("override-colors")]
        internal bool OverrideColors
        {
            get => _OverrideColors;
            set
            {
                _OverrideColors = value;
                Settings.instance.OverrideColors = value;
                if (ColorContainer) ColorContainer.SetActive(value);
                NotifyPropertyChanged();
            }
        }

        [UIValue("left-color")]
        internal Color LeftColor
        {
            get => _LeftColor;
            set
            {
                _LeftColor = value;
                Settings.instance.Color_LSaber = ColorHelper.ColorToHex(value);
                NotifyPropertyChanged();
            }
        }

        [UIValue("right-color")]
        internal Color RightColor
        {
            get => _RightColor;
            set
            {
                _RightColor = value;
                Settings.instance.Color_RSaber = ColorHelper.ColorToHex(value);
                NotifyPropertyChanged();
            }
        }

        //Actions
        [UIAction("enabled-onchange")]
        internal void _EnableToggleAction(bool newval)
        {
            Settings.instance.EnableTweaks = newval;
            BurnFlowCoordinator flowCord = UISingleton.flowCoordinator;
            if (newval) Plugin.ApplyPatches();
            else Plugin.Disable();
        }

        [UIAction("set-preset")]
        public void SetPreset(string presetTag)
        {
            var presetEntries = PresetHelper.TrailPreset.ConfigDict;
            if (presetEntries.ContainsKey(presetTag))
            {
                PresetHelper.ApplyPreset(presetEntries[presetTag]);
            }
            else return;
            var config = Settings.instance;
            LeftColor = ColorHelper.HexToColor(config.Color_LSaber);
            RightColor = ColorHelper.HexToColor(config.Color_RSaber);
            OverrideColors = config.OverrideColors;
            UISingleton.flowCoordinator.ReloadUIValues();
        }
    }
}
