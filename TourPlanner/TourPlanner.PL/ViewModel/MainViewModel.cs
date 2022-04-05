using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Factory;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public SearchBarViewModel SearchBar { get; set; }
        public ToursViewModel Tours { get; set; }
        public TourDetailViewModel TourDetail { get; set; }
        public MenuBarViewModel MenuBar { get; set; }
        public LogsViewModel Logs { get; set; }

        public IControllerFactory ControllerFactory { get; set; }

        public MainViewModel(SearchBarViewModel searchBar, ToursViewModel tours, TourDetailViewModel tourDetail, MenuBarViewModel menuBar, LogsViewModel logs, IControllerFactory controllerFactory)
        {
            SearchBar = searchBar;
            Tours = tours;
            TourDetail = tourDetail;
            MenuBar = menuBar;
            Logs = logs;
            ControllerFactory = controllerFactory;

            Setup();

            //controller have to be used like this to relase recources, would management by factory be an improvement?
            //using var tourController = ControllerFactory.CreateTourController();
        }

        private void Setup()
        {
            if (SearchBar != null)
                SearchbarSetup();
            if (Tours != null)
                ToursSetup();
            if (TourDetail != null)
                TourDetailSetup();
        }

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

        private void SearchbarSetup()
        {
            SearchBar.SearchEvent += (s, e) =>
            {
                if (SearchBar.SearchText != null)
                    SearchTours(SearchBar.SearchText);
            };
        }

        private void LoadTours()
        {
            using var tourController = ControllerFactory.CreateTourController();
            Tours.AllTours = new(tourController.GetAllTours());
        }

        private void SearchTours(string searchText)
        {
            using var tourController = ControllerFactory.CreateTourController();
            var res = from e in tourController.GetAllTours() where e.Name.Contains(searchText) select e;
            Tours.AllTours = new(res);
            Console.WriteLine($"{searchText} was searched");
        }
    }
}
