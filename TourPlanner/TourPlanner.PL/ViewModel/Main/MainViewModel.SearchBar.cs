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
            var res = tourController.Search(searchText);
            Tours.AllTours = new(res);
            Tours.SelectedTour = null;
            TourDetail.SelectedTour = null;
            Logs.TourLogs = new();
            TourDetail.ChildFriendliness = null;
            TourDetail.Popularity = null;
        }
    }
}
