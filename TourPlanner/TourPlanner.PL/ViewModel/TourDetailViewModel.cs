using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel
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
            }
        }
    }
}
