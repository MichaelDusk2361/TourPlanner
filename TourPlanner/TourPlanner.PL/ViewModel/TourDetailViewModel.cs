using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Model;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel
{
    public class TourDetailViewModel : BaseViewModel
    {
        private bool _isReadOnly = true;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                ApplyButtonIsEnabled = !value;
                OnPropertyChanged();
            }
        }

        private bool _applyButtonIsEnabled = false;
        public bool ApplyButtonIsEnabled
        {
            get => _applyButtonIsEnabled;
            set
            {
                _applyButtonIsEnabled = value;
                OnPropertyChanged();
            }
        }

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

        public TourDetailViewModel()
        {
            ApplyChangesCommand = new RelayCommand((_) =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(SelectedTour));
            });
        }

        public ICommand ApplyChangesCommand { get; }
    }
}
