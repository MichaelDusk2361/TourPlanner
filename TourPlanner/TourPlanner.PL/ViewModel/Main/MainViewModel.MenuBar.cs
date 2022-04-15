using System;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void MenuBarSetup()
        {
            AddImportEvent();
            AddExportEvent();
            AddToursSummaryEvent();
            AddTourReportEvent();
        }

        private void AddTourReportEvent()
        {
            MenuBar.TourReportEvent += (sender, e) =>
            {

            };
        }

        private void AddToursSummaryEvent()
        {
            MenuBar.ToursSummaryEvent += (sender, e) =>
            {

            };
        }

        private void AddExportEvent()
        {
            MenuBar.ExportEvent += (sender, e) =>
            {

            };
        }

        private void AddImportEvent()
        {
            MenuBar.ImportEvent += (sender, e) =>
            {

            };
        }
    }
}
