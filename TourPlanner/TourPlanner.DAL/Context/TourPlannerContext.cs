using TourPlanner.DAL.ORM;
using TourPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.DAL.Context {
    public class TourPlannerContext : DBContext {

        //load connection string from config file
        public TourPlannerContext() : base("Host=localhost;Username=postgres;Password=postgres;Database=mtcgdb;IncludeErrorDetail=true") {
            LoadTable<Tour>();
            LoadTable<TourLog>();
        }
    }
}
