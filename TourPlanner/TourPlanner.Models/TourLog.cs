using TourPlanner.Model.Attributes;

namespace TourPlanner.Model
{
    [DataSource("logs")]
    public class TourLog : ITEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Comment { get; set; } = string.Empty;
        public int Difficulty { get; set; } = 0;
        public string CompletionTime { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}