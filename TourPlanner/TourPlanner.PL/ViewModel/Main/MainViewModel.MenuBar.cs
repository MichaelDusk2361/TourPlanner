using Microsoft.Win32;
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
                tourController.Export($"ToursPlannerExport_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Guid.NewGuid()}.json");
                s_logger.Info("User generated export");
            };
        }

        private void AddImportEvent()
        {
            MenuBar.ImportEvent += (sender, e) =>
            {
                using (var tourController = ControllerFactory.CreateTourController())
                {
                    OpenFileDialog dlg = new();
                    dlg.DefaultExt = ".json";
                    dlg.Filter = "Json files (*.json)|*.json";
                    var result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        tourController.Import(filename);
                        s_logger.Info("User imported data from file");
                    }
                }
                LoadTours();
            };
        }
    }
}
