using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourPlanner.PL.Helper;
using TourPlanner.Model;
using TourPlanner.PL.View;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class ToursViewModel : BaseViewModel
    {
        public ICommand AddTourCommand { get; }
        public ICommand RemoveTourCommand { get; }

        public ToursViewModel()
        {
            AddTourCommand = new RelayCommand((_) =>
            {
                AddTourEvent?.Invoke(this, EventArgs.Empty);
            });

            RemoveTourCommand = new RelayCommand((_) =>
            {
                RemoveTourEvent?.Invoke(this, EventArgs.Empty);
            });
        }


        private Tour? _selectedTour;
        public Tour? SelectedTour
        {
            get => _selectedTour;
            set
            {
                _selectedTour = value;
                Console.WriteLine(SelectedTour?.Name);
                SelectedTourChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? SelectedTourChanged = null;
        public event EventHandler? AddTourEvent = null;
        public event EventHandler? RemoveTourEvent = null;


        private ObservableCollection<Tour>? _data;
        public ObservableCollection<Tour> AllTours
        {
            get => _data ??= new ObservableCollection<Tour>();
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
    }
}
