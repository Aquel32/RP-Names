using System;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Server;

namespace AquelPlugin.Events
{
    public class ServerHandler
    {
        Random rng = new Random();

        internal void RoundStarted()
        {
            bool kierownikBadanIsSet = false;
            bool dowodcaOchronyIsSet = false;
            bool dozorcaIsSet = false;

            foreach(var playerFromDictionary in Player.Dictionary)
            {
                Player player = playerFromDictionary.Value;

                player.DisplayNickname = GetRandomCharacterName();

                switch (player.Role.Type)
                {
                    case PlayerRoles.RoleTypeId.ClassD:
                        player.DisplayNickname = "D-" + rng.Next(1111, 9999);
                        if(dozorcaIsSet == false && rng.Next(1,2) == 2)
                        {
                            dozorcaIsSet = true;
                            player.DisplayNickname = "Dozorca " + GetRandomCharacterName();
                            player.AddItem(ItemType.KeycardJanitor, 1);
                        }
                        break;
                    case PlayerRoles.RoleTypeId.FacilityGuard:
                        if (dowodcaOchronyIsSet == false && rng.Next(1, 2) == 2)
                        {
                            player.DisplayNickname = "Dowódca " + GetRandomCharacterName();
                            dowodcaOchronyIsSet = true;
                        }
                        break;
                    case PlayerRoles.RoleTypeId.Scientist:
                        if (kierownikBadanIsSet == false && rng.Next(1, 2) == 2)
                        {
                            kierownikBadanIsSet = true;

                            player.DisplayNickname = "Kierownik " + GetRandomCharacterName();

                            foreach (Item item in player.Items)
                            {
                                if(item.Type == ItemType.KeycardScientist)
                                {
                                    player.RemoveItem(item);
                                }
                            }

                            player.AddItem(ItemType.KeycardResearchCoordinator, 1);
                        }
                        break;
                    case PlayerRoles.RoleTypeId.Scp173:
                        player.Role.Set(PlayerRoles.RoleTypeId.Scp096);
                        break;
                    default:
                        player.DisplayNickname = GetRandomCharacterName();
                        break;
                }

                foreach (var _playerFromDictionary in Player.Dictionary)
                {
                    Player _player = playerFromDictionary.Value;

                    if(dozorcaIsSet == false)
                    {
                        if (_player.Role == PlayerRoles.RoleTypeId.ClassD)
                        {
                            dozorcaIsSet = true;

                            player.DisplayNickname = "Dozorca " + GetRandomCharacterName();
                            player.AddItem(ItemType.KeycardJanitor, 1);
                        }
                    }
                    if(dowodcaOchronyIsSet == false)
                    {
                        if (_player.Role == PlayerRoles.RoleTypeId.FacilityGuard)
                        {
                            dowodcaOchronyIsSet = true;

                            player.DisplayNickname = "Dowódca " + GetRandomCharacterName();
                        }
                    }
                    if(kierownikBadanIsSet == false)
                    {
                        if(_player.Role ==  PlayerRoles.RoleTypeId.Scientist)
                        {
                            kierownikBadanIsSet = true;

                            player.DisplayNickname = "Kierownik " + GetRandomCharacterName();

                            foreach (Item item in player.Items)
                            {
                                if (item.Type == ItemType.KeycardScientist)
                                {
                                    player.RemoveItem(item);
                                }
                            }

                            player.AddItem(ItemType.KeycardResearchCoordinator, 1);
                        }
                    }
                }

                    if (player.Role.Team == PlayerRoles.Team.SCPs)
                {
                    player.DisplayNickname = "SCP";
                }

                player.ShowHint("<align=left> \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n <size=50%>" + player.DisplayNickname + "</align>", 999999999999999f);

            }
        }

        internal void RespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                bool dowodcaIsSet = false;

                foreach (Player player in ev.Players)
                {
                    if (dowodcaIsSet == false && rng.Next(1, 2) == 2)
                    {
                        dowodcaIsSet = true;

                        player.DisplayNickname = "Dowódca " + GetRandomCharacterName();
                        player.ShowHint("<align=left> \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n <size=50%>" + player.DisplayNickname + "</align>", 999999999999999f);
                    }
                }

                foreach (Player player in ev.Players)
                {
                    if (dowodcaIsSet == false)
                    {
                       dowodcaIsSet = true;

                       player.DisplayNickname = "Dowódca " + GetRandomCharacterName();
                       player.ShowHint("<align=left> \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n <size=50%>" + player.DisplayNickname + "</align>", 999999999999999f);
                    }
                }
            }
        }

        public string GetRandomCharacterName()
        {
            string name = Main.Instance.Config.characterNames[rng.Next(0, Main.Instance.Config.characterNames.Length)];
            return name;
        }
    }
}
