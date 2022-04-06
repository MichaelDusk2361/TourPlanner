using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Factory;
using TourPlanner.Model;
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

            //controller have to be used like this to relase recources, would management by factory be an improvement?
            //using var tourController = ControllerFactory.CreateTourController();
            
            //where should uow save() be called? if the controller is disposed?

            //use some ioc container to intercept methods and inject unitofwork into methods?
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
    }
}
