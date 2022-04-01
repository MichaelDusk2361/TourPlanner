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

namespace TourPlanner.PL.ViewModel
{

    public class ToursViewModel : BaseViewModel
    {
        public ICommand AddTourCommand { get; }
        public ICommand RemoveTourCommand { get; }

        public ToursViewModel()
        {
            AddTourCommand = new RelayCommand((_) =>
            {
                Data.Add(new() { Name = "new tour" });
            });

            RemoveTourCommand = new RelayCommand((_) =>
            {
                //this stuff needs to be wraped in BL who also updates DB by using DAL
                if(SelectedTour != null)
                    Data.Remove(SelectedTour);
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
                //call event which updates tourdetailview and logsview
            }
        }

        public event EventHandler? SelectedTourChanged = null;


        private ObservableCollection<Tour>? _data;
        public ObservableCollection<Tour> Data
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
