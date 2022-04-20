using System.Linq;
using System.Threading.Tasks;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void TourDetailSetup()
        {
            AddCancelChangesEvent();
            AddApplyChangesEvent();
            AddCalculateChildFriendlinessEvent();
            AddCalculatePopularityEvent();
        }

        private void AddCalculatePopularityEvent()
        {
            Logs.CalculatePopularityEvent += (sender, args) =>
            {
                if (Tours.SelectedTour != null)
                {
                    using var tourController = ControllerFactory.CreateTourController();
                    TourDetail.Popularity = tourController.CalculatePopularity(Tours.SelectedTour);
                }
            };
        }

        private void AddCalculateChildFriendlinessEvent()
        {
            Logs.CalculateChildFriendlinessEvent += (sender, args) =>
            {
                if (Tours.SelectedTour != null)
                {
                    using var tourController = ControllerFactory.CreateTourController();
                    TourDetail.ChildFriendliness = tourController.CalculateChildFriendliness(Tours.SelectedTour);
                }
            };
        }

        private void AddCancelChangesEvent()
        {
            TourDetail.CancelChangesEvent += (s, e) =>
            {
                if (Tours.SelectedTour != null)
                    TourDetail.SelectedTour = new(Tours.SelectedTour);
            };
        }

        private void AddApplyChangesEvent()
        {
            TourDetail.ApplyChangesEvent += async (s, e) =>
            {
                await ApplyChangesAsync();
            };
        }

        public async Task ApplyChangesAsync()
        {
            if (TourDetail.SelectedTour != null)
            {
                using (var tourController = ControllerFactory.CreateTourController())
                {
                    await tourController.RequestAndUpdateTour(TourDetail.SelectedTour);
                };
                LoadTours();
                Tours.SelectedTour = Tours.AllTours.Where(x => x.Id == TourDetail.SelectedTour.Id).First();
            }
        }
    }
}
