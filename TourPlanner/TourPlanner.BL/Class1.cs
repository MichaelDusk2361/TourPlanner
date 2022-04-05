using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL.Mock;

namespace TourPlanner.BL
{
    public class Class1
    {
        public static void TestDALMock()
        {
            using var uowm = new UnitOfWorkMock();

            uowm.TourRepository.Insert(new() { Name = "AHHHHHHHHH" });
            uowm.TourRepository.Get().ForEach(x => Console.WriteLine(x.Name));
            uowm.TourLogRepository.Get().ForEach(x => Console.WriteLine(x.Date));
        }
    }
}
