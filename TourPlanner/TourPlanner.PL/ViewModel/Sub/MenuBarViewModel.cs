using System;
using System.Windows.Input;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.ViewModel.Sub
{
    public class MenuBarViewModel : BaseViewModel
    {
        public event EventHandler? ExportEvent = null;
        public ICommand ExportCommand { get; }
        public event EventHandler? ImportEvent = null;
        public ICommand ImportCommand { get; }
        public event EventHandler? ToursSummaryEvent = null;
        public ICommand ToursSummaryCommand { get; }
        public event EventHandler? TourReportEvent = null;
        public ICommand TourReportCommand { get; }

        public MenuBarViewModel()
        {
            ExportCommand = new RelayCommand((_) =>
            {
                ExportEvent?.Invoke(this, EventArgs.Empty);
            });
            ImportCommand = new RelayCommand((_) =>
            {
                ImportEvent?.Invoke(this, EventArgs.Empty);
            });
            ToursSummaryCommand = new RelayCommand((_) =>
            {
                ToursSummaryEvent?.Invoke(this, EventArgs.Empty);
            });
            TourReportCommand = new RelayCommand((_) =>
            {
                TourReportEvent?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
