using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL;

namespace TourPlanner.PL
{
    public class Programm
    {
        [STAThread]
        public static void Main(string[] args)
        {

            Class1.TestDALMock();

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
