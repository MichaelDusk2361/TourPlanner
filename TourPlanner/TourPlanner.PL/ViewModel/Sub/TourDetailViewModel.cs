using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
        }

        public TourDetailViewModel()
        {
            ApplyChangesCommand = new RelayCommand((_) =>
            {
                ApplyChangesEvent?.Invoke(this, EventArgs.Empty);
                Console.WriteLine(JsonConvert.SerializeObject(SelectedTour));
            });

            CancelChangesCommand = new RelayCommand((_) =>
            {
                CancelChangesEvent?.Invoke(this, EventArgs.Empty);
            });
        }

        public event EventHandler? ApplyChangesEvent = null;
        public event EventHandler? CancelChangesEvent = null;

        public ICommand ApplyChangesCommand { get; }
        public ICommand CancelChangesCommand { get; }
    }
}
