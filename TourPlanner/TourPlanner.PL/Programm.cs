using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL;
using TourPlanner.BL.Controller;
using TourPlanner.Common;

namespace TourPlanner.PL
{
    public class Programm
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ConfigFile.Parse("AppConfig.json");

            Class1.RunAsync();

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
