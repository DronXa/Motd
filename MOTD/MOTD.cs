using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDG.Unturned;
using Rocket.Unturned.Player;
using Rocket.API.Collections;
using Rocket.Unturned;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Core.Logging;

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
