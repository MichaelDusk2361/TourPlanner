using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TourDetail.ApplyChangesEvent += (s, e) =>
            {
                Tours.SelectedTour = TourDetail.SelectedTour;
                using var tourController = ControllerFactory.CreateTourController();
                if (Tours.SelectedTour != null)
                {
                    tourController.UpdateTour(Tours.SelectedTour);
                    Tours.AllTours = new(tourController.GetAllTours());
                }
            };
        }
    }
}
