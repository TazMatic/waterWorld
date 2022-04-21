using JsonConfigSaver;
using Newtonsoft.Json;
using System;


namespace seaLevel.Config
{
    public sealed class SeaLevelConfig : JsonEcoConfig
    {
        //Save
        [JsonProperty]
        public float CurrentSeaLevel = 60;
        [JsonProperty]
        public float SeaLevelChangeRate = 1;
        [JsonProperty]
        public float SeaLevelChangeTimeHours = 6;


        public SeaLevelConfig(string plugin, string name) : base(plugin, name)
        {
            Console.WriteLine(seaLevelMod.prefix + "Full config controller registred!");
            //Restructure as to pass the config throughout the program
            ConfigGetter configGetter = new ConfigGetter();
        }

        public void updateCurrentSeaLevel()
        {
            this.save();
        }

    }
}
