using System;
using System.Windows.Input;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class SearchBarViewModel : BaseViewModel
    {
        public event EventHandler? SearchEvent = null;

        public ICommand SearchCommand { get; }

        private string? _searchText = string.Empty;
        public string? SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public SearchBarViewModel()
        {
            SearchCommand = new RelayCommand((_) =>
            {
                 SearchEvent?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
