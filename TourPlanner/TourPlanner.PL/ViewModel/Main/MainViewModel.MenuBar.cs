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
                if (Tours.SelectedTour != null)
                {
                    using var tourController = ControllerFactory.CreateTourController();
                    tourController.GenerateTourReport(Tours.SelectedTour);
                }
            };
        }

        private void AddToursSummaryEvent()
        {
            MenuBar.ToursSummaryEvent += (sender, e) =>
            {
                using var tourController = ControllerFactory.CreateTourController();
                tourController.GenerateToursSummary();
            };
        }

        private void AddExportEvent()
        {
            MenuBar.ExportEvent += (sender, e) =>
            {
                using var tourController = ControllerFactory.CreateTourController();
                tourController.Export("ExportTest.json");
            };
        }

        private void AddImportEvent()
        {
            MenuBar.ImportEvent += (sender, e) =>
            {
                // use select folder dialog??
                using var tourController = ControllerFactory.CreateTourController();
                tourController.Import("ExportTest.json");
                LoadTours();
            };
        }
    }
}
