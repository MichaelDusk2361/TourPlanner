using TourPlanner.BL.MapQuestAPI;
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
            throw new NotImplementedException();
        }

        public void AddTour(Tour tour)
        {
            _uow.TourRepository.Insert(tour);
        }
        public int? CalculatePopularity()
        {
            return 2;
        }

        public int? CalculateChildFriendliness()
        {
            return 1;
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

            //update tour in db
            _uow.TourRepository.Update(tour);
        }


        private static string CreateImageUrl(Tour tour)
        {
            return $"Maps/{tour.Id}.png";
        }
    }
}
