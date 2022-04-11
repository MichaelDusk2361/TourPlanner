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
using Newtonsoft.Json;

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
                Console.WriteLine(JsonConvert.SerializeObject(SelectedTour));
                SelectedTourChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged();
            }
        }

        public event EventHandler? SelectedTourChanged = null;
        public event EventHandler? AddTourEvent = null;
        public event EventHandler? RemoveTourEvent = null;


        private ObservableCollection<Tour>? _allTours;
        public ObservableCollection<Tour> AllTours
        {
            get => _allTours ??= new ObservableCollection<Tour>();
            set
            {
                _allTours = value;
                OnPropertyChanged();
            }
        }
    }
}
