using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourPlanner.Model;
using TourPlanner.PL.View;

namespace TourPlanner.PL.ViewModel
{

    public class ToursViewModel : BaseViewModel
    {
        private Tour? _selectedTour;
        public Tour? SelectedTour
        {
            get => _selectedTour;
            set
            {
                _selectedTour = value;
                Console.WriteLine(SelectedTour?.Name);
                SelectedTourChanged?.Invoke(this, value);
                //call event which updates tourdetailview and logsview
            }
        }

        public event EventHandler<Tour?>? SelectedTourChanged = null;


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
