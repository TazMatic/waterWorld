using Eco.Gameplay.Players;
using Eco.Simulation;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using System;
using System.Linq;
using Eco.Gameplay.Aliases;

namespace seaLevel.Commands
{
    public class AdminCommands : IChatCommandHandler
    {
        [ChatCommand("changeSeaLevel", "Changes the sea level to the desired height", ChatAuthorizationLevel.Admin)]
        public static void changeSeaLevel(User user, String argsString = "")
        {
            LocStringBuilder locStringBuilder = new LocStringBuilder();
            String[] args = argsString.Split(' ');
            if (args[0].Count() < 1)
            {
                locStringBuilder.Append("Usage: /changeSeaLevel int");
                user.Msg(locStringBuilder.ToLocString());
                return;
            }

            ClimateSim CS = new ClimateSim();
            seaLevelMod.config.CurrentSeaLevel = float.Parse(args[0]);
            seaLevelMod.config.updateCurrentSeaLevel();
            CS.SetSeaLevel(seaLevelMod.config.CurrentSeaLevel);
            locStringBuilder.Clear();
            locStringBuilder.Append("New sea level is " + seaLevelMod.config.CurrentSeaLevel);
            user.Msg(locStringBuilder.ToLocString());
        }
    }
}
