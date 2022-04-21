using seaLevel.Config;
using Eco.Simulation;
using System.Threading;
using System;

namespace seaLevel.ThreadWatcher
{
    class seaLevelWatcher
    {
        public static void seaLevelRaise()
        {
            while (true)
            {
                //43200000
                int rate = (int)(seaLevelMod.config.SeaLevelChangeTimeHours * 60 * 60 * 1000);
                Thread.Sleep(rate);
                ClimateSim CS = new ClimateSim();
                ConfigGetter Config = new ConfigGetter();
                float newSeaLevel = Config.getSeaLevel();
                CS.SetSeaLevel(newSeaLevel);
                seaLevelMod.config.CurrentSeaLevel = newSeaLevel;
                seaLevelMod.config.updateCurrentSeaLevel();
            }
        }
    }
}
