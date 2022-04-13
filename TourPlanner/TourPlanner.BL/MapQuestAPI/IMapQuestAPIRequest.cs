using Newtonsoft.Json.Linq;

namespace TourPlanner.BL.MapQuestAPI
{
    public interface IMapQuestAPIRequest
    {
        public JObject? MapQuestResponse { get; }

        public Task ExecuteAsync(string from, string to, string transportMedium);

        public Task<byte[]> GetRouteImageAsync();
    }
}
