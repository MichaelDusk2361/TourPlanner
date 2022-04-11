using System;
using TourPlanner.BL.Factory;
using TourPlanner.PL.ViewModel.Sub;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel : BaseViewModel
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
        }

        private void Setup()
        {
            if (SearchBar != null)
                SearchbarSetup();
            if (Tours != null)
                ToursSetup();
            if (TourDetail != null)
                TourDetailSetup();
            if (MenuBar != null)
                MenuBarSetup();
            if (Logs != null)
                LogsSetup();
        }

    }
}
