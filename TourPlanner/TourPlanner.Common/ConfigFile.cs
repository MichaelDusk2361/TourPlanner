using Newtonsoft.Json;

namespace TourPlanner.Common
{
    public class ConfigFile
    {
        public static Dictionary<string, string>? Parse(string path)
        {
            var configFile = File.ReadAllText(path);
            var parsedConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(configFile);
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