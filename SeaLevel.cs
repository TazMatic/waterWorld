using Eco.Core.Plugins.Interfaces;
//using EcoColorLib;
using seaLevel.Config;
using seaLevel.ThreadWatcher;
using System;
using System.Threading;

namespace seaLevel
{
    public class seaLevelMod : IModKitPlugin, IServerPlugin
    {
        public static String prefix = "seaLevel: ";
        //public static String coloredPrefix = ChatFormat.Green.Value + ChatFormat.Bold.Value + prefix + ChatFormat.Clear.Value;
        public static String coloredPrefix = "";
        public static SeaLevelConfig config;

        private Boolean started = false;
        public string GetStatus()
        {
            if (!started)
            {
                this.start();
                started = true;
            }
            return "";
        }

        public void start()
        {
            Console.WriteLine(seaLevelMod.prefix + " starting !");

            config = new SeaLevelConfig("SeaLevel", "config");
            if (config.exist())
            {
                config = config.reload<SeaLevelConfig>();
            }
            else
            {
                config.save();
            }

            Thread lsr = new Thread(() => seaLevelWatcher.seaLevelRaise());
            lsr.Start();
            Console.WriteLine(seaLevelMod.prefix + " starting to flood the world!");
        }
    }
}
