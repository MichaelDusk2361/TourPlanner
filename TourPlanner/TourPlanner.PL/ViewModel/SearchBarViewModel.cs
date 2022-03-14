using System;
using System.Windows.Input;
using TourPlanner.BL.Helper;

namespace TourPlanner.PL.ViewModel
{
    public class SearchBarViewModel : BaseViewModel
    {
        public event EventHandler<string> SearchTextChanged;

        public ICommand SearchCommand { get; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                Console.WriteLine("search text set");
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public SearchBarViewModel()
        {
            SearchCommand = new RelayCommand((_) =>
            {
                Console.WriteLine($"invoked serach text command. Text: {SearchText}");
                if(SearchTextChanged == null)
                    Console.WriteLine("event is null");
                else 
                    SearchTextChanged.Invoke(this, SearchText);
            });
        }
    }
}
