using TourPlanner.Model.Attributes;

namespace TourPlanner.Model
{
    [DataSource("tourlogs")]
    public class TourLog : ITEntity
    {
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public float Distance { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}