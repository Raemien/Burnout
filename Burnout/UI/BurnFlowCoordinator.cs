using BeatSaberMarkupLanguage;
using HMUI;

namespace Burnout
{
    public class BurnFlowCoordinator : FlowCoordinator
    {
        private BurnMainSettings mainView;

        private void Awake()
        {
            if (!mainView)
            {
                mainView = BeatSaberUI.CreateViewController<BurnMainSettings>();
            }
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Burnout");
                showBackButton = true;
                ProvideInitialViewControllers(mainView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }

    }
}
