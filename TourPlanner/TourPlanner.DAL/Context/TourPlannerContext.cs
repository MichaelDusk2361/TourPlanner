using TourPlanner.Common;
using TourPlanner.Model;

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
            //"Host= ;Username= ;Password= ;Database= ;IncludeErrorDetail= "
            s_connectionString = $"Host={ConfigFile.AppSettings("Host")};Username={ConfigFile.AppSettings("Username")};Password={ConfigFile.AppSettings("Password")};Database={ConfigFile.AppSettings("Database")};IncludeErrorDetail={ConfigFile.AppSettings("IncludeErrorDetail")}";
            return s_connectionString;
        }
    }
}
