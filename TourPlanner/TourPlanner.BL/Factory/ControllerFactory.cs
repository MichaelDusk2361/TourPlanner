using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Controller;
using TourPlanner.DAL;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactory : IControllerFactory
    {
        public TourController CreateTourController()
        {
            return new(new UnitOfWork());
        }

        public TourLogController CreateTourLogController()
        {
            return new(new UnitOfWork());
        }
    }
}
