using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void ToursSetup()
        {
            LoadTours();
            AddSelectedTourChangedEvent();
        }

        private void AddSelectedTourChangedEvent()
        {
            Tours.SelectedTourChanged += (s, e) =>
            {
                if (Tours.SelectedTour != null)
                    TourDetail.SelectedTour = new(Tours.SelectedTour);
            };
        }


        private void LoadTours()
        {
            using var tourController = ControllerFactory.CreateTourController();
            Tours.AllTours = new(tourController.GetAllTours());
        }
    }
}
