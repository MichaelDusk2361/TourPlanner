using NUnit.Framework;
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
            Main = new MainViewModel(SearchBar, Tours, null, null, null)
            {
                ExampleTours = new()
                {
                    new() { Name = "1. Tour" },
                    new() { Name = "2. Tour" },
                    new() { Name = "3. Tour" },
                    new() { Name = "4. Tour" },
                    new() { Name = "5. Tour" },
                    new() { Name = "6. Tour" },
                    new() { Name = "7. Tour" },
                    new() { Name = "8. Tour" },
                    new() { Name = "9. Tour" },
                    new() { Name = "10. Tour" },
                }
            };
        }

        [Test]
        public void TestExampleData_ShouldContainExampleList()
        {
            Assert.AreEqual(expected: 10, actual: Tours.Data.Count);
        }

        [Test]
        public void TestSearchCommand_ListShouldOnlyContainRelevantItems()
        {
            SearchBar.SearchText = "1";
            SearchBar.SearchCommand.Execute(null);
            Assert.AreEqual(expected: 2, actual: Tours.Data.Count);
        }
    }
}