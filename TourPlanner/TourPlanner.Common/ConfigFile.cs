using Newtonsoft.Json;

namespace TourPlanner.Common
{
    public class ConfigFile
    {
        public static Dictionary<string, string> Parse(string path)
        {
            try
            {
                var configFile = File.ReadAllText(path);
                var parsedConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(configFile);
                return parsedConfig;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"{path} is missing");
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{path} has invalid format");
                throw e;
            }
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