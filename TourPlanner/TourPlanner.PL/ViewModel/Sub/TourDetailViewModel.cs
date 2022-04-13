using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using TourPlanner.Model;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class TourDetailViewModel : BaseViewModel
    {
        private Tour? _selectedTour = null;
        public Tour? SelectedTour
        {
            get
            {
                return _selectedTour;
            }
            set
            {
                _selectedTour = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SourceUri));
            }
        }

        public TourDetailViewModel()
        {
            ApplyChangesCommand = new RelayCommand((_) =>
            {
                ApplyChangesEvent?.Invoke(this, EventArgs.Empty);
            });

            CancelChangesCommand = new RelayCommand((_) =>
            {
                CancelChangesEvent?.Invoke(this, EventArgs.Empty);
            });
        }

        public string? SourceUri
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SelectedTour?.ImageUrl);
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public event EventHandler? ApplyChangesEvent = null;
        public event EventHandler? CancelChangesEvent = null;

        public ICommand ApplyChangesCommand { get; }
        public ICommand CancelChangesCommand { get; }
    }
}
