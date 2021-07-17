using BS_Utils.Utilities;

namespace Burnout
{
    internal class PluginConfig
    {
        public bool RegenerateConfig = true;
    }


    class Settings : PersistentSingleton<Settings>
    {
        private Config config;

        // Main
        public bool EnableTweaks
        {
            get => config.GetBool("Main", "Enable Tweaks", false);
            set => config.SetBool("Main", "Enable Tweaks", value);
        }
        public float BurnLifespan
        {
            get => config.GetFloat("Main", "Burn Lifetime", 1f);
            set => config.SetFloat("Main", "Burn Lifetime", value);
        }

        public float BurnOpacity
        {
            get => config.GetFloat("Main", "Burn Opacity", 1f);
            set => config.SetFloat("Main", "Burn Opacity", value);
        }

        // Color Management
        public bool OverrideColors
        {
            get => config.GetBool("Colors", "Override Colors", false);
            set => config.SetBool("Colors", "Override Colors", value);
        }
        public string Color_LSaber
        {
            get => config.GetString("Colors", "Left Burn Color", "#FF0000");
            set => config.SetString("Colors", "Left Burn Color", value);
        }
        public string Color_RSaber
        {
            get => config.GetString("Colors", "Right Burn Color", "#0000FF");
            set => config.SetString("Colors", "Right Burn Color", value);
        }

        public void Awake()
        {
            config = new Config("Burnout");
        }
    }

}