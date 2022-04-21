namespace seaLevel.Config
{
    public class ConfigGetter
    {
        public float getSeaLevel()
        {
            double needed = seaLevelMod.config.SeaLevelChangeRate + seaLevelMod.config.CurrentSeaLevel;

            return (float)needed;
        }
    }
}

