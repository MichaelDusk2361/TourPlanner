using Newtonsoft.Json;

namespace TourPlanner.Common
{
    public class ConfigFile
    {

        private readonly static Dictionary<string, Dictionary<string, string>> s_configFiles = new();

        public static Dictionary<string, string> Parse(string path)
        {
            if(s_configFiles.ContainsKey(path))
                return s_configFiles[path];

            var configFile = File.ReadAllText(path);
            var parsedConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(configFile);

            if (parsedConfig == null)
                throw new ArgumentException("Could not parse specified config file");

            s_configFiles[path] = parsedConfig;

            return parsedConfig;
        }

        public static bool TryParse(string path, out Dictionary<string, string>? parsedFile)
        {
            try
            {
                parsedFile = Parse(path);
                return true;
            }
            catch (Exception)
            {
                parsedFile = null;
                return false;
            }
        }
    }
}