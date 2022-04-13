using TourPlanner.BL.Controller;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.DAL;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactory : IControllerFactory
    {
        public TourController CreateTourController()
        {
            return new(new UnitOfWork(), new MapQuestAPIRequest());
        }

        public TourLogController CreateTourLogController()
        {
            return new(new UnitOfWork(), new MapQuestAPIRequest());
        }
    }
}
