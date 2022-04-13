using NUnit.Framework;
using TourPlanner.BL.Factory;
using TourPlanner.DAL.Mock;
using TourPlanner.PL.ViewModel;
using TourPlanner.PL.ViewModel.Main;
using TourPlanner.PL.ViewModel.Sub;

namespace TourPlanner.Test.PL
{
    public class TestTourViewModel
    {
        public SearchBarViewModel SearchBar { get; set; }
        public ToursViewModel Tours { get; set; }
        public TourDetailViewModel TourDetail { get; set; }
        public MenuBarViewModel MenuBar { get; set; }
        public LogsViewModel Logs { get; set; }
        public MainViewModel Main { get; set; }


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

        [Test]
        public void TestExampleData_ShouldContainExampleList()
        {
            Assert.AreEqual(expected: 5, actual: Tours.AllTours.Count);
        }

        [Test]
        public void TestSearchCommand_ListShouldOnlyContainRelevantItems()
        {
            SearchBar.SearchText = "1";
            SearchBar.SearchCommand.Execute(null);
            Assert.AreEqual(expected: 1, actual: Tours.AllTours.Count);
        }
    }
}