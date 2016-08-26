using Rocket.API;

namespace SilK.MOTD
{
    public class MOTDConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool ShowOnConnect;
        public string Message;
        public string Link;

        public void LoadDefaults()
        {
            Enabled = true;
            ShowOnConnect = true;
            Message = "RocketMod!";
            Link = "http://rocketmod.net";
        }
    }
}
