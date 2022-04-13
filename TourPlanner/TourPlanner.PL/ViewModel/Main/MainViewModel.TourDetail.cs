using System.Linq;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void TourDetailSetup()
        {
            AddCancelChangesEvent();
            AddApplyChangesEvent();
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
                if (TourDetail.SelectedTour != null)
                {
                    using (var tourController = ControllerFactory.CreateTourController())
                    {
                        //maybe only make api call if from, to or transport type have changed? 
                        await tourController.RequestAndUpdateTour(TourDetail.SelectedTour);
                    };
                    LoadTours();
                    Tours.SelectedTour = Tours.AllTours.Where(x => x.Id == TourDetail.SelectedTour.Id).First();
                }

            };
        }
    }
}
