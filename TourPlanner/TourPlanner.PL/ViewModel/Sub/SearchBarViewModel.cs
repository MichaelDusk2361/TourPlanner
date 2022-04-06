using System;
using System.Windows.Input;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class SearchBarViewModel : BaseViewModel
    {
        public event EventHandler? SearchEvent = null;

        public ICommand SearchCommand { get; }

        private string? _searchText = null;
        public string? SearchText
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
                if(SearchEvent == null)
                    Console.WriteLine("event is null");
                else 
                    SearchEvent.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
