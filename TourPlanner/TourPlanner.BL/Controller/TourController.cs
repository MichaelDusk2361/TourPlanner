using TourPlanner.BL.MapQuestAPI;
using TourPlanner.Common;
using TourPlanner.DAL;
using TourPlanner.Model;

namespace TourPlanner.BL.Controller
{
    public class TourController : BaseController
    {
        internal TourController(IUnitOfWork uow, IMapQuestAPIRequest mapQuestAPI) : base(uow, mapQuestAPI)
        {
        }

        public List<Tour> GetAllTours()
        {
            return _uow.TourRepository.Get();
        }

        public void DeleteTour(Tour tour)
        {
            _uow.TourRepository.Delete(tour);
            if (File.Exists(tour.ImageUrl))
                File.Delete(tour.ImageUrl);
        }

        public List<Tour> Search(string searchText)
        {
            s_logger.Debug($"'{searchText}' was searched");
            var res = (from tour in _uow.TourRepository.Get() where TourContainsString(tour, searchText) || TourLogContainString(tour, searchText) select tour).ToList();
            return res ?? new();
        }

        private bool TourLogContainString(Tour tour, string searchText)
        {
            return _uow.TourLogRepository.Get(log => log.TourId == tour.Id).Any(log => log.Comment.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private static bool TourContainsString(Tour tour, string searchText)
        {
            return tour.Start.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                tour.TransportType.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                tour.Destination.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                tour.Description.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                tour.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
        }

        public void AddTour(Tour tour)
        {
            _uow.TourRepository.Insert(tour);
        }
        public int? CalculatePopularity(Tour tour)
        {
            var res = _uow.TourLogRepository.Get(log => log.TourId == tour.Id, null);
            return res.Count;
        }

        public int? CalculateChildFriendliness(Tour tour)
        {
            var res = _uow.TourLogRepository.Get(log => log.TourId == tour.Id, null);
            if (res.Count == 0)
                return null;

            var difficultySum = 0;
            res.ForEach(x => difficultySum += x.Difficulty);

            return difficultySum / res.Count;
        }

        public async Task RequestAndUpdateTour(Tour tour)
        {
            //fetch data from api
            await _mapQuestAPI.ExecuteAsync(tour.Start, tour.Destination, tour.TransportType);

            //Load Image and store in filesystem
            var imageBytes = await _mapQuestAPI.GetRouteImageAsync();
            if (imageBytes.Length > 0)
            {
                tour.ImageUrl = CreateImageUrl(tour);
                await File.WriteAllBytesAsync(tour.ImageUrl, imageBytes);
            }

            //update tour object
            var responseParser = new MapQuestAPIResponseParser(_mapQuestAPI.MapQuestResponse);
            tour.TourDistance = responseParser.GetDistance() ?? "";
            tour.EstimatedTime = responseParser.GetTime() ?? "";

            if (tour.EstimatedTime == "")
                s_logger.Error("Could not get estimated time from open map");

            if (tour.TourDistance == "")
                s_logger.Error("Could not get tour distance from open map");

            //update tour in db
            _uow.TourRepository.Update(tour);
        }


        private static string CreateImageUrl(Tour tour)
        {
            return $"{ConfigFile.AppSettings("MapDir")}{tour.Id}.png";
        }
    }
}
