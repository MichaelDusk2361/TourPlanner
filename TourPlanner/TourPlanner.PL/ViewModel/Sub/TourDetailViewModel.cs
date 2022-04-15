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
                if(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) != null &&  SelectedTour?.ImageUrl != null)
                    return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SelectedTour?.ImageUrl);
                return null;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public event EventHandler? ApplyChangesEvent = null;
        public event EventHandler? CancelChangesEvent = null;
        private int? _childFriendliness;
        public int? ChildFriendliness
        {
            get
            {
                return _childFriendliness;
            }
            set
            {
                _childFriendliness = value;
                OnPropertyChanged();
            }
        }

        private int? _popularity;
        public int? Popularity
        {
            get
            {
                return _popularity;
            }
            set
            {
                _popularity = value;
                OnPropertyChanged();
            }
        }

        public ICommand ApplyChangesCommand { get; }
        public ICommand CancelChangesCommand { get; }
    }
}
