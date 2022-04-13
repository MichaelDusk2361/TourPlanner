using System;
using TourPlanner.BL;
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
