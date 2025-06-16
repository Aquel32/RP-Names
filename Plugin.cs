using AquelPlugin.Events;
using Exiled.API.Features;

namespace AquelPlugin
{
    public class Main : Plugin<Config>
    {
        private static readonly Main Singleton = new Main();
        public static Main Instance => Singleton;


        ServerHandler ServerHandler;
        ClientHandler ClientHandler;

        public override void OnEnabled()
        {
            ServerHandler = new ServerHandler();
            ClientHandler = new ClientHandler();


            Exiled.Events.Handlers.Server.RoundStarted += ServerHandler.RoundStarted;
            Exiled.Events.Handlers.Server.RespawningTeam += ServerHandler.RespawningTeam;
            Exiled.Events.Handlers.Player.ChangingRole += ClientHandler.ChangingRole;

        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= ServerHandler.RoundStarted;
            Exiled.Events.Handlers.Server.RespawningTeam -= ServerHandler.RespawningTeam;
            Exiled.Events.Handlers.Player.ChangingRole -= ClientHandler.ChangingRole;


            ServerHandler = null;
            ClientHandler = null;
        }
    }
}
