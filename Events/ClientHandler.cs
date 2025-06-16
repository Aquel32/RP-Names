using System;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;


namespace AquelPlugin.Events
{
    public class ClientHandler
    {
        Random rng = new Random();

        internal void ChangingRole(ChangingRoleEventArgs ev)
        {
            ev.Player.DisplayNickname = GetRandomCharacterName();

            switch (ev.NewRole)
            {
                case PlayerRoles.RoleTypeId.ClassD:
                    ev.Player.DisplayNickname = "D-" + rng.Next(1111, 9999); 
                    break;
                default:
                    ev.Player.DisplayNickname = GetRandomCharacterName();
                    break;
            }

            if(ev.NewRole.GetTeam() == PlayerRoles.Team.SCPs)
            {
                ev.Player.DisplayNickname = "SCP";
            }

            if (ev.NewRole.GetTeam() == PlayerRoles.Team.Dead)
            {
                ev.Player.DisplayNickname = null;
            }

            ev.Player.ShowHint("<align=left> \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n <size=50%>" + ev.Player.DisplayNickname + "</align>", 999999999999999f);
        }

        public string GetRandomCharacterName()
        {
            string name = Main.Instance.Config.characterNames[rng.Next(0, Main.Instance.Config.characterNames.Length)];
            return name;
        }

    }
}
