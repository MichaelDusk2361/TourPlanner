using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel
{
    public class LogsViewModel
    {
        public IEnumerable<TourLog> Data { get; set; }

        public LogsViewModel()
        {
            Data = new List<TourLog>()
            {
                new() { Date = DateTime.Now, Distance = 10, Duration = new(10) },
                new() { Date = DateTime.Now, Distance = 10, Duration = new(10) },
                new() { Date = DateTime.Now, Distance = 10, Duration = new(10) },
                new() { Date = DateTime.Now, Distance = 10, Duration = new(10) },
                new() { Date = DateTime.Now, Distance = 10, Duration = new(10) },
            };
        }
    }
}
