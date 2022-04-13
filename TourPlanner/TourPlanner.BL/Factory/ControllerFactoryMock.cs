using TourPlanner.BL.Controller;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.DAL.Mock;

namespace TourPlanner.BL.Factory
{
    public class ControllerFactoryMock : IControllerFactory
    {
        public TourController CreateTourController()
        {
            return new(new UnitOfWorkMock(), new MapQuestAPIRequestMock());
        }

        public TourLogController CreateTourLogController()
        {
            return new(new UnitOfWorkMock(), new MapQuestAPIRequestMock());
        }
    }
}
