using TourPlanner.Model.Attributes;


namespace TourPlanner.Model
{
    [DataSource("tours")]
    public class Tour : ITEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Start { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string TransportType { get; set; } = string.Empty;
        public double TourDistance { get; set; } = 0;
        public string EstimatedTime { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public int Version { get; set; }

        public Tour()
        {

        }

        public Tour(Tour origin)
        {
            Name = origin.Name;
            Description = origin.Description;
            Start = origin.Start;
            Destination = origin.Destination;
            TransportType = origin.TransportType;
            TourDistance = origin.TourDistance;
            EstimatedTime = origin.EstimatedTime;
            ImageUrl = origin.ImageUrl;
            Id = origin.Id;
            Version = origin.Version;
        }
    
    }
}