using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TourPlanner.Model;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class LogsViewModel : BaseViewModel
    {

        private TourLog? _selectedTourLog;
        public TourLog? SelectedTourLog
        {
            get
            {
                return _selectedTourLog;
            }
            set
            {
                _selectedTourLog = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler? CalculateChildFriendlinessEvent;
        public event EventHandler? CalculatePopularityEvent;

        public ICommand AddTourLogCommand { get; }
        public ICommand RemoveTourLogCommand { get; }

        public event EventHandler? AddTourLogEvent;
        public event EventHandler? RemoveTourLogEvent;

        private ObservableCollection<TourLog> _tourLogs = new();
        public ObservableCollection<TourLog> TourLogs
        {
            get
            {
                return _tourLogs;
            }
            set
            {
                _tourLogs = value;
                OnPropertyChanged();
            }
        }

        public LogsViewModel()
        {
            AddTourLogCommand = new RelayCommand((_) =>
            {
                AddTourLogEvent?.Invoke(this, EventArgs.Empty);
                ReevaluateCalculations();
            });

            RemoveTourLogCommand = new RelayCommand((_) =>
            {
                RemoveTourLogEvent?.Invoke(this, EventArgs.Empty);
                ReevaluateCalculations();
            });
        }

        internal void ReevaluateCalculations()
        {
            CalculateChildFriendlinessEvent?.Invoke(this, EventArgs.Empty);
            CalculatePopularityEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}