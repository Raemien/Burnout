using BeatSaberMarkupLanguage;
using HMUI;

namespace Burnout
{
    public class BurnFlowCoordinator : FlowCoordinator
    {
        private BurnMainSettings mainView;
        private BurnSideMenu sideView;

        public void ReloadUIValues()
        {
            if (sideView) sideView.ReloadValues();
        }

        private void Awake()
        {
            if (!mainView)
            {
                mainView = BeatSaberUI.CreateViewController<BurnMainSettings>();
            }
            if (!sideView)
            {
                sideView = BeatSaberUI.CreateViewController<BurnSideMenu>();
            }
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Burnout");
                showBackButton = true;
                ProvideInitialViewControllers(mainView, sideView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }

    }
}
