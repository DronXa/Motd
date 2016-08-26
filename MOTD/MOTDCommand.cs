using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilK.MOTD
{
    public class MOTDCommand : IRocketCommand
    {
        public List<String> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }

        public String Help
        {
            get { return "Message Of The Day."; }
        }

        public String Name
        {
            get { return "motd"; }
        }

        public List<String> Permissions
        {
            get { return new List<string>(); }
        }

        public String Syntax
        {
            get { return ""; }
        }

        public void Execute(IRocketPlayer caller, String[] command)
        {
            if (command.Length != 0)
            {
                UnturnedChat.Say(caller, MOTD.Instance.Translate("invalid_parameters"));
                return;
            }
            UnturnedChat.Say(caller, MOTD.Instance.Translate("show_motd"));
            ((UnturnedPlayer)caller).Player.sendBrowserRequest(MOTD.Instance.Configuration.Instance.Message, MOTD.Instance.Configuration.Instance.Link);
            Logger.Log(MOTD.Instance.Translate("show_motd_log", caller.DisplayName));
        }
    }
}
