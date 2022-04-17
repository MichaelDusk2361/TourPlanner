using NUnit.Framework;
using System.IO;
using TourPlanner.BL.Factory;
using TourPlanner.Common;
using TourPlanner.DAL.Mock;
using TourPlanner.PL.ViewModel;
using TourPlanner.PL.ViewModel.Main;
using TourPlanner.PL.ViewModel.Sub;

namespace TourPlanner.Test.PL
{
    public class TestViewModelBase
    {
        public SearchBarViewModel SearchBar { get; set; }
        public ToursViewModel Tours { get; set; }
        public TourDetailViewModel TourDetail { get; set; }
        public MenuBarViewModel MenuBar { get; set; }
        public LogsViewModel Logs { get; set; }
        public MainViewModel Main { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ConfigFile.Parse("AppConfig.json");
            Directory.CreateDirectory(ConfigFile.AppSettings("MapDir"));
        }

        [SetUp]
        public void Setup()
        {
            DBMock.Reset();
            SearchBar = new SearchBarViewModel();
            Tours = new ToursViewModel();
            MenuBar = new MenuBarViewModel();
            Logs = new LogsViewModel();
            TourDetail = new TourDetailViewModel();
            Main = new MainViewModel(SearchBar, Tours, TourDetail, MenuBar, Logs, new ControllerFactoryMock());
        }

        [OneTimeTearDown]
        public void RemoveMapsDir()
        {
            Directory.Delete(ConfigFile.AppSettings("MapDir"), true);
        }
    }
}
