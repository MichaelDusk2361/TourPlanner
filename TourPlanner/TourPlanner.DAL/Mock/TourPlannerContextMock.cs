using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.DAL.Mock
{
    public class TourPlannerContextMock : DBContextMock
    {
        public TourPlannerContextMock()
        {
            LoadTable<Tour>();
            LoadTable<TourLog>();
        }
    }
}
