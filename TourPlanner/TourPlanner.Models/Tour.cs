using TourPlanner.Model.Attributes;


namespace TourPlanner.Model
{
    [DataSource("tours")]
    public class Tour : ITEntity
    {
        private string _transportType = "fastest";

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Start { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string TransportType
        {
            get
            {
                return _transportType;
            }
            set
            {
                if (value == "fastest" || value == "pedestrian" || value == "shortest" || value == "bicycle")
                {
                    _transportType = value;
                }
                else
                {
                    _transportType = "fastest";
                }
            }
        }
        public string TourDistance { get; set; } = string.Empty;
        public string EstimatedTime { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public int Version { get; set; } = 1;

        public Tour()
        {

        }

        public Tour(TourToTourLogRelation origin)
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