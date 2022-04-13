using System;
using System.IO;
using TourPlanner.Common;

namespace TourPlanner.PL
{
    public class Programm
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ConfigFile.Parse("AppConfig.json");
            Directory.CreateDirectory(ConfigFile.AppSettings("MapDir"));

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
