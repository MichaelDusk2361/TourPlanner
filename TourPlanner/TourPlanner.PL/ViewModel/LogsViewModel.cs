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

        public void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == nameof(ITEntity.Id))
            {
                e.Cancel = true;
            }
            else if (propertyDescriptor.DisplayName == nameof(ITEntity.Version))
            {
                e.Cancel = true;
            }
        }
    }
}
