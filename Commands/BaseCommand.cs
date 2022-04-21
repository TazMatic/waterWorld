using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using System;


namespace seaLevel.Commands
{
    class BaseCommand : IChatCommandHandler
    {
        [ChatCommand("checkSeaLevel", "Checks the current sea level", ChatAuthorizationLevel.User)]
        public static void checkSeaLevel(User user, String argsString = "")
        {
            LocStringBuilder locStringBuilder = new LocStringBuilder();
            locStringBuilder.Append(seaLevelMod.coloredPrefix + seaLevelMod.config.CurrentSeaLevel);
            user.Msg(locStringBuilder.ToLocString());
        }
    }
}
