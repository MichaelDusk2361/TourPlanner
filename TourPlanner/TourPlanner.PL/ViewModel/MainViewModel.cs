using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.PL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel(SearchBarViewModel searchBar)
        {
            Console.WriteLine("made it here");
            searchBar.SearchTextChanged += (sender, searchText) =>
            {
                SearchTours(searchText);
            };
        }

        private void SearchTours(string searchText)
        {
            Console.WriteLine($"{searchText} was searched");
        }
    }
}
