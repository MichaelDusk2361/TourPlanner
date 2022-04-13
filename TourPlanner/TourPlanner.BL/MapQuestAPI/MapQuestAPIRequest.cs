using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TourPlanner.Common;
using TourPlanner.Common.Logging;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestAPIRequest : IMapQuestAPIRequest
    {
        public JObject? MapQuestResponse { get; private set; } = null;

        private static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

        public async Task ExecuteAsync(string from, string to, string transportMedium)
        {
            try
            {
                using var client = new HttpClient();
                var key = ConfigFile.AppSettings("MapQuestApiKey");
                var stringTask = client.GetStringAsync($"http://www.mapquestapi.com/directions/v2/route?key={key}&from={from}&to={to}&unit=k&routeType={transportMedium}");
                var msg = await stringTask;

                MapQuestResponse = JsonConvert.DeserializeObject<JObject>(msg);
            }
            catch (HttpRequestException e)
            {
                s_logger.Error($"exception from directions mapquestapirequest {e}");
            }
        }

        public async Task<byte[]> GetRouteImageAsync()
        {
            try
            {
                if (MapQuestResponse == null)
                    throw new InvalidOperationException("Image cant be fetched before route data has been received");

                using var client = new HttpClient();
                var key = ConfigFile.AppSettings("MapQuestApiKey");

                var responseParser = new MapQuestAPIResponseParser(MapQuestResponse);
                var url = $"http://open.mapquestapi.com/staticmap/v5/map?key={key}&session={responseParser.GetSession()}&boundingbox={responseParser.GetBoundingBox()}&size=640,480&format=png";
                var res = await client.GetByteArrayAsync(url);
                return res;
            }
            catch (HttpRequestException e)
            {
                s_logger.Error($"exception from openmap mapquestapirequest {e}");
            }
            return Array.Empty<byte>();
        }
    }
}
