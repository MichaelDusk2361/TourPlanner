using Newtonsoft.Json;
using TourPlanner.Common.Exceptions;

namespace TourPlanner.Common
{
    public static class ConfigFile
    {

        private static Dictionary<string, string>? s_configFile = null;

        public static void Parse(string path)
        {
            if (s_configFile != null)
                return;

            var configFile = File.ReadAllText(path);
            var parsedConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(configFile);

            if (parsedConfig == null)
                throw new InvalidConfigFileFormatException("Format of config file is invalid");

            s_configFile = parsedConfig;
        }

        public static string AppSettings(string key)
        {
            if (s_configFile == null)
                throw new InvalidOperationException("Config file has not been parsed");
            return s_configFile[key];
        }

        public static bool TryParse(string path)
        {
            try
            {
                if(s_configFile == null)
                    Parse(path);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}