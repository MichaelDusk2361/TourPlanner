using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourPlanner.Model;

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
                Console.WriteLine(JsonConvert.SerializeObject(value));
                _selectedTourLog = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<TourLog>? _tourLogs;
        public ObservableCollection<TourLog>? TourLogs
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
            TourLogs = new()
            {
                new(),
                new(),
                new(),
                new(),
                new(),
            };
        }

    }
}