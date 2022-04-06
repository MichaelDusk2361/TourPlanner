using System;
using System.Collections.Generic;
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
        public IEnumerable<TourLog> Data { get; set; }

        public LogsViewModel()
        {
            Data = new List<TourLog>()
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
