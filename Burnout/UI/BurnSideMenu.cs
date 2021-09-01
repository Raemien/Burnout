using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using UnityEngine;
using Burnout.Helpers;

namespace Burnout
{
    class BurnSideMenu : BSMLResourceViewController
    {
        public override string ResourceName => "Burnout.Views.SideMenu.bsml";

        internal float _BurnLifespan = Settings.instance.BurnLifespan;
        internal float _BurnOpacity = Settings.instance.BurnOpacity;
        internal float _BurnScale = Settings.instance.BurnScale;
        public void ReloadValues()
        {
            BurnLifespan = Settings.instance.BurnLifespan;
            BurnOpacity = Settings.instance.BurnOpacity;
            BurnScale = Settings.instance.BurnScale;
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

        [UIValue("burn-scale")]
        internal float BurnScale
        {
            get => _BurnScale;
            set
            {
                _BurnScale = value;
                Settings.instance.BurnScale = value;
                NotifyPropertyChanged();
            }
        }
    }
}
