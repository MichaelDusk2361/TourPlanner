using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Controller;

namespace TourPlanner.BL.Factory
{
    public interface IControllerFactory
    {
        public TourController CreateTourController();
        public TourLogController CreateTourLogController();
    }
}
