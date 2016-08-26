using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace SilK.MOTD
{
    public class MOTD : RocketPlugin<MOTDConfiguration>
    {
        public static MOTD Instance;
        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
        }
        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            if (Configuration.Instance.Enabled && Configuration.Instance.ShowOnConnect && player.HasPermission("motd"))
            {
                UnturnedChat.Say(player, Translate("show_motd"));
                player.Player.sendBrowserRequest(Configuration.Instance.Message, Configuration.Instance.Link);
                Logger.Log(Translate("show_motd_log", player.DisplayName));
            }
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList
                {
                    {
                        "show_motd",
                        "Showing the Message Of The Day."
                    },
                    {
                        "show_motd_log",
                        "Showing \"{0}\" the Message Of The Day."
                    },
                    {
                        "invalid_parameters",
                        "Invalid Parameters."
                    }
                };
            }
        }
    }
}
