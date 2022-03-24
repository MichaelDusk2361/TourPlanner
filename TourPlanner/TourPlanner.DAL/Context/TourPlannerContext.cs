using TourPlanner.DAL.ORM;
using TourPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TourPlanner.DAL.Context
{
    public class TourPlannerContext : DBContext
    {

        private static string? s_connectionString = null;
        public TourPlannerContext() : base(s_connectionString ?? ParseConnectionStringFromConfig())
        {
            LoadTable<Tour>();
            LoadTable<TourLog>();
        }

        private static string ParseConnectionStringFromConfig()
        {
            try
            {
                var configFile = File.ReadAllText("AppConfig.json");
                var parsedConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(configFile);
                //"Host= ;Username= ;Password= ;Database= ;IncludeErrorDetail= "
                s_connectionString = $"Host={parsedConfig["Host"]};Username={parsedConfig["Username"]};Password={parsedConfig["Password"]};Database={parsedConfig["Database"]};IncludeErrorDetail={parsedConfig["IncludeErrorDetail"]}";
                return s_connectionString;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("AppConfig.json is missing");
                throw e;
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("AppConfig.json is missing parameters");
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("AppConfig.json has invalid format");
                throw e;
            }
        }
    }
}
