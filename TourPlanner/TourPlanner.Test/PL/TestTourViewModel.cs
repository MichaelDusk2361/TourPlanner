using NUnit.Framework;
using TourPlanner.BL.Factory;
using TourPlanner.PL.ViewModel;

namespace TourPlanner.Test.PL
{
    public class TestTourViewModel
    {
        public ToursViewModel Tours { get; set; }
        public SearchBarViewModel SearchBar { get; set; }
        public MainViewModel Main { get; set; }


        [SetUp]
        public void Setup()
        {
            SearchBar = new SearchBarViewModel();
            Tours = new ToursViewModel();
            Main = new MainViewModel(SearchBar, Tours, null, null, null, new ControllerFactoryMock());
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