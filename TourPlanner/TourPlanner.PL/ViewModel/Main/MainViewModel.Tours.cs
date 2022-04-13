using System;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void ToursSetup()
        {
            LoadTours();
            AddSelectedTourChangedEvent();
            AddAddTourEvent();
            AddRemoveTourEvent();
        }

        private void AddRemoveTourEvent()
        {
            Tours.RemoveTourEvent += (s, e) =>
            {
                if (Tours.SelectedTour == null)
                    return;

                using (var tourController = ControllerFactory.CreateTourController())
                {
                    tourController.DeleteTour(Tours.SelectedTour);
                }
                LoadTours();
                Tours.SelectedTour = null;
            };
        }

        private void AddAddTourEvent()
        {
            Tours.AddTourEvent += (s, e) =>
            {
                using var tourController = ControllerFactory.CreateTourController();
                tourController.AddTour(new()
                {
                    Name = "New tour",
                    Id = Guid.NewGuid(),
                });
                Tours.AllTours = new(tourController.GetAllTours());
            };
        }

        private void AddSelectedTourChangedEvent()
        {
            Tours.SelectedTourChanged += (s, e) =>
            {
                if (Tours.SelectedTour != null)
                {
                    TourDetail.SelectedTour = new(Tours.SelectedTour);
                    using var tourLogController = ControllerFactory.CreateTourLogController();
                    Logs.TourLogs = new(tourLogController.GetTourLogsForTour(Tours.SelectedTour));
                }
            };
        }


        private void LoadTours()
        {
            using var tourController = ControllerFactory.CreateTourController();
            Tours.AllTours = new(tourController.GetAllTours());
        }
    }
}
