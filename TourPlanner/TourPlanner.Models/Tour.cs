using TourPlanner.Model.Attributes;


namespace TourPlanner.Model
{
    [DataSource("tours")]
    public class Tour : ITEntity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}