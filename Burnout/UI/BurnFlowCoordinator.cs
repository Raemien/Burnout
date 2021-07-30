using BeatSaberMarkupLanguage;
using HMUI;

namespace Burnout
{
    public class BurnFlowCoordinator : FlowCoordinator
    {
        private BurnMainSettings mainView;
        private BurnPresetSettings presetView;

        private void Awake()
        {
            if (!mainView)
            {
                mainView = BeatSaberUI.CreateViewController<BurnMainSettings>();
            }
            if (!presetView)
            {
                presetView = BeatSaberUI.CreateViewController<BurnPresetSettings>();
            }
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Burnout");
                showBackButton = true;
                ProvideInitialViewControllers(mainView, presetView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }

    }
}
