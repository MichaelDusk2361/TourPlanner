using System;
using System.Linq;
using TourPlanner.Model;
using TourPlanner.PL.EditTourLog;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void LogsSetup()
        {
            AddAddTourLogEvent();
            AddRemoveTourLogEvent();
            AddEditTourLogEvent();
        }

        private void AddEditTourLogEvent()
        {
            Logs.EditTourLogEvent += (sender, e) =>
            {
                if (Logs.SelectedTourLog != null)
                {
                    var editTourLogDialog = new EditTourLogDialog
                    {
                        Log = new(Logs.SelectedTourLog)
                    };
                    var dialogResult = editTourLogDialog.ShowDialog();

                    if ((dialogResult ?? false) && editTourLogDialog.Log != null)
                    {
                        using (var tourLogController = ControllerFactory.CreateTourLogController())
                        {
                            tourLogController.UpdateTourLog(editTourLogDialog.Log);
                        };

                        LoadTourLogs();
                        Logs.ReevaluateCalculations();
                    }
                }
            };
        }

        private void AddRemoveTourLogEvent()
        {
            Logs.RemoveTourLogEvent += (sender, e) =>
            {
                if (Logs.SelectedTourLog != null)
                {
                    using var tourLogController = ControllerFactory.CreateTourLogController();
                    tourLogController.RemoveTourLog(Logs.SelectedTourLog);

                    var found = Logs.TourLogs.ToList().Find(x => x.Id == Logs.SelectedTourLog.Id);
                    if (found != null)
                        Logs.TourLogs.Remove(found);
                    Logs.SelectedTourLog = null;
                }
            };
        }

        private void AddAddTourLogEvent()
        {
            Logs.AddTourLogEvent += (sender, e) =>
            {
                if (Tours.SelectedTour != null)
                {
                    using var tourLogController = ControllerFactory.CreateTourLogController();

                    var tourLog = new TourLog()
                    {
                        Date = DateTime.Now,
                        Difficulty = 5,
                        Id = Guid.NewGuid(),
                        TourId = Tours.SelectedTour.Id,
                        Rating = 5,
                    };

                    tourLogController.AddTourLog(tourLog);
                    Logs.TourLogs.Add(tourLog);
                    Logs.SelectedTourLog = tourLog;
                }

            };
        }

        private void LoadTourLogs()
        {
            if (Tours.SelectedTour != null)
            {
                using var tourLogController = ControllerFactory.CreateTourLogController();
                Logs.TourLogs = new(tourLogController.GetTourLogsForTour(Tours.SelectedTour));
            }
        }

        private static readonly Random _random = new();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
