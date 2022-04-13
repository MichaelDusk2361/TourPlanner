using System;
using System.Linq;
using TourPlanner.Model;

namespace TourPlanner.PL.ViewModel.Main
{
    public partial class MainViewModel
    {
        private void LogsSetup()
        {
            AddAddTourLogEvent();
            AddRemoveTourLogEvent();
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
                        Comment = RandomString(15),
                        Date = DateTime.Now,
                        CompletionTime = _random.Next(10, 1000).ToString(),
                        Difficulty = _random.Next(1, 10),
                        Id = Guid.NewGuid(),
                        TourId = Tours.SelectedTour.Id,
                        Rating = _random.Next(1, 10),
                    };

                    tourLogController.AddTourLog(tourLog);
                    Logs.TourLogs.Add(tourLog);
                }

            };
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
