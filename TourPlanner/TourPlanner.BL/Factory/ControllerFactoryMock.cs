using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Controller;
using TourPlanner.DAL.Mock;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactoryMock : IControllerFactory
    {
        public TourController CreateTourController()
        {
            return new(new UnitOfWorkMock());
        }

        public TourLogController CreateTourLogController()
        {
            return new(new UnitOfWorkMock());
        }
    }
}
