using System;
using System.Linq;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void SearchbarSetup()
        {
            SearchBar.SearchEvent += (s, e) =>
            {
                if (SearchBar.SearchText != null)
                    SearchTours(SearchBar.SearchText);
            };
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
