using TourPlanner.Model.Attributes;

namespace TourPlanner.Model
{
    [DataSource("logs")]
    public class TourLog : ITEntity
    {
        public Guid TourId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Comment { get; set; } = string.Empty;
        private int _difficulty = 1;
        public int Difficulty
        {
            get => _difficulty;
            set
            {
                if (value < 1)
                    _difficulty = 1;
                else if (value > 10)
                    _difficulty = 10;
                else
                    _difficulty = value;
            }
        }
        private int _completionTime = 1;
        public int CompletionTime
        {
            get => _completionTime;
            set
            {
                if (value < 1)
                    _completionTime = 1;
                else
                    _completionTime = value;
            }
        }
        private int _rating = 1;
        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 1)
                    _rating = 1;
                else if (value > 10)
                    _rating = 10;
                else
                    _rating = value;
            }
        }
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