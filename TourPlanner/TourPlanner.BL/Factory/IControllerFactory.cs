using TourPlanner.BL.Controller;

namespace TourPlanner.BL.Factory
{
    public interface IControllerFactory
    {
        public TourController CreateTourController();
        public TourLogController CreateTourLogController();
    }
}
