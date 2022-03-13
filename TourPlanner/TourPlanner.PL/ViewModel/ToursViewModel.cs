using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel
{

    public class ToursViewModel : BaseViewModel
    {
        private ObservableCollection<Tour>? _tours;
        public ObservableCollection<Tour> Tours
        {
            get => _tours ??= new ObservableCollection<Tour>();
            set
            {
                _tours = value;
                OnPropertyChanged();
            }
        }
    }
}
