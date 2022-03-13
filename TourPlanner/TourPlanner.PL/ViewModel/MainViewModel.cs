using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public SearchBarViewModel SearchBar { get; set; }
        public ToursViewModel Tours { get; set; }
        public TourDetailViewModel TourDetail { get; set; }
        public MenuBarViewModel MenuBar { get; set; }
        public LogsViewModel Logs { get; set; }


        private List<Tour> _exampleTours = new()
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
        };

        public MainViewModel(SearchBarViewModel searchBar, ToursViewModel tours, TourDetailViewModel tourDetail, MenuBarViewModel menuBar, LogsViewModel logs)
        {
            SearchBar = searchBar;
            Tours = tours;
            TourDetail = tourDetail;
            MenuBar = menuBar;
            Logs = logs;
            SearchbarSetup();
            LoadTours();
        }

        private void SearchbarSetup()
        {
            SearchBar.SearchTextChanged += (sender, searchText) =>
            {
                if (searchText != null)
                    SearchTours(searchText);
            };
        }

        private void LoadTours()
        {
            Tours.Tours = new(_exampleTours);
        }

        private void SearchTours(string searchText)
        {
            var res = from e in _exampleTours where e.Name.Contains(searchText) select e;
            Tours.Tours = new(res);
            Console.WriteLine($"{searchText} was searched");
        }
    }
}
