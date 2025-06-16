using System;

using CommandSystem;

using Exiled.API.Features;
using Exiled.API.Features.Pickups;


namespace AquelPlugin.Commands
{
    using System;

    using CommandSystem;

    using Exiled.API.Features;
    using Exiled.API.Features.Pickups;

    /// <summary>
    /// This is an example of how commands should be made.
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Scale : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "skala";

        /// <inheritdoc/>
        public string[] Aliases { get; } = new[] { "sk" };

        /// <inheritdoc/>
        public string Description { get; } = "Change size of player model";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = null;

            Player player = Player.Get(sender);
            float scale = float.Parse(arguments.FirstElement());
            player.Scale = new UnityEngine.Vector3(scale, scale, scale);

            return true;
        }
    }
}
