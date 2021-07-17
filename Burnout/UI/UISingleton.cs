using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

namespace Burnout
{
    public class UISingleton : PersistentSingleton<UISingleton>
    {
        public static MenuButton dtButton = new MenuButton("Burnout", "Modify burn mark settings.", OpenBGMenu);
        public static BurnFlowCoordinator flowCoordinator;

        private static void OpenBGMenu()
        {
            if (flowCoordinator == null)
            {
                flowCoordinator = BeatSaberUI.CreateFlowCoordinator<BurnFlowCoordinator>();
            }
            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(flowCoordinator, null, HMUI.ViewController.AnimationDirection.Horizontal, false);
        }
        public static void RegMenuButton()
        {
            MenuButtons.instance.RegisterButton(dtButton);
        }
        public static void RemoveMenuButton()
        {
            MenuButtons.instance.UnregisterButton(dtButton);
        }
    }
}
