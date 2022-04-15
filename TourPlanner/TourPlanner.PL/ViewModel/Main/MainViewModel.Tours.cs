using Newtonsoft.Json;
using System;
using TourPlanner.Model;

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

                s_logger.Info($"User deleted tour");
            };
        }

        private void AddAddTourEvent()
        {
            Tours.AddTourEvent += (s, e) =>
            {
                s_logger.Info($"User added new tour");
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
                    s_logger.Debug($"User selected different tour: {Tours.SelectedTour.Id}");
                    TourDetail.SelectedTour = new(Tours.SelectedTour);
                    LoadTourLogs();
                    Logs.ReevaluateCalculations();
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
