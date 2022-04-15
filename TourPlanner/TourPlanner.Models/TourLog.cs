using TourPlanner.Model.Attributes;

namespace TourPlanner.Model
{
    [DataSource("logs")]
    public class TourLog : ITEntity
    {
        public Guid TourId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Comment { get; set; } = string.Empty;
        public int Difficulty { get; set; } = 0;
        public string CompletionTime { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public Guid Id { get; set; }
        public int Version { get; set; } = 1;

        public TourLog()
        {

        }


        public TourLog(TourLog origin)
        {
            TourId = origin.TourId;
            Date = origin.Date;
            Comment = origin.Comment;
            Difficulty = origin.Difficulty;
            CompletionTime = origin.CompletionTime;
            Rating = origin.Rating;
            Id = origin.Id;
            Version = origin.Version;
        }
    }
}