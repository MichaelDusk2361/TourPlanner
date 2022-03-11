using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.PL.ViewModel
{

    /// <summary>
    /// This class should do all the calls to BL and Model
    /// </summary>
    public class MainViewModel : BaseViewModel
    {

        public SearchBarViewModel SearchBar { get; set; }
        public ToursViewModel Tours { get; set; }

        public MainViewModel(SearchBarViewModel searchBar, ToursViewModel tours)
        {
            SearchBar = searchBar;
            Tours = tours;
            searchBar.SearchTextChanged += (sender, searchText) =>
            {
                SearchTours(searchText);
            };
            Console.WriteLine("search event has been assigned");
        }

        private void SearchTours(string searchText)
        {
            Tours.SearchResult = $"{searchText} was searched";
            Console.WriteLine($"{searchText} was searched");
        }
    }
}
