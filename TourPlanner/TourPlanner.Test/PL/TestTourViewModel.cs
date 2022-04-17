using NUnit.Framework;
using TourPlanner.BL.Factory;
using TourPlanner.DAL.Mock;
using TourPlanner.PL.ViewModel;
using TourPlanner.PL.ViewModel.Main;
using TourPlanner.PL.ViewModel.Sub;

namespace TourPlanner.Test.PL
{
    public class TestTourViewModel : TestViewModelBase
    {

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