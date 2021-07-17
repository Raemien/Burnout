using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Utilities;
using BeatSaberMarkupLanguage.Components.Settings;
using UnityEngine;
using Burnout.Helpers;
using UnityEngine.UI;

namespace Burnout
{
    class BurnMainSettings : BSMLResourceViewController
    {
        public override string ResourceName => "Burnout.Views.MainMenu.bsml";

        internal bool _EnableTweaks = Settings.instance.EnableTweaks;
        internal float _BurnLifespan = Settings.instance.BurnLifespan;
        internal float _BurnOpacity = Settings.instance.BurnOpacity;

        internal bool _OverrideColors = Settings.instance.OverrideColors;
        internal Color _LeftColor = ColorHelper.HexToColor(Settings.instance.Color_LSaber);
        internal Color _RightColor = ColorHelper.HexToColor(Settings.instance.Color_RSaber);

        [UIObject("color-container")]
        internal GameObject ColorContainer;

        [UIValue("master-enabled")]
        internal bool EnableTweaks
        {
            get => _EnableTweaks;
            set => _EnableTweaks = value;
        }

        [UIValue("burn-lifetime")]
        internal float BurnLifespan
        {
            get => _BurnLifespan;
            set
            {
                _BurnLifespan = value;
                Settings.instance.BurnLifespan = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("burn-opacity")]
        internal float BurnOpacity
        {
            get => _BurnOpacity;
            set
            {
                _BurnOpacity = value;
                Settings.instance.BurnOpacity = value;
                NotifyPropertyChanged();
            }
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

        [UIAction("reset")]
        internal void ResetSettings()
        {   
            Settings.instance.OverrideColors = true;
            Settings.instance.BurnLifespan = 0.5f;
        }
    }
}
