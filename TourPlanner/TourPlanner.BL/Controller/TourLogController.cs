using TourPlanner.BL.MapQuestAPI;
using TourPlanner.DAL;
using TourPlanner.Model;

namespace TourPlanner.BL.Controller
{
    public class TourLogController : BaseController
    {

        internal TourLogController(IUnitOfWork uow, IMapQuestAPIRequest mapQuestAPI) : base(uow, mapQuestAPI)
        {
        }

        public void AddTourLog(TourLog tourLog)
        {
            _uow.TourLogRepository.Insert(tourLog);
        }

        public List<TourLog> GetTourLogsForTour(Tour tour)
        {
            return _uow.TourLogRepository.Get(tourLog => tourLog.TourId == tour.Id);
        }

        public void RemoveTourLog(TourLog tourLog)
        {
            _uow.TourLogRepository.Delete(tourLog);
        }
    }
}
