using Newtonsoft.Json.Linq;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestAPIResponseParser
    {
        public JObject Response { get; private set; }

        public MapQuestAPIResponseParser(JObject? response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            Response = response;
        }


        public string? GetBoundingBox()
        {
            return $"{Response["route"]?["boundingBox"]?["ul"]?["lat"]?.ToString().Replace(',', '.')}," +
                $"{Response["route"]?["boundingBox"]?["ul"]?["lng"]?.ToString().Replace(',', '.')}," +
                $"{Response["route"]?["boundingBox"]?["lr"]?["lat"]?.ToString().Replace(',', '.')}," +
                $"{Response["route"]?["boundingBox"]?["lr"]?["lng"]?.ToString().Replace(',', '.')}";
        }

        public string? GetSession()
        {
            return Response["route"]?["sessionId"]?.ToString();
        }

        public string? GetDistance()
        {
            return Response["route"]?["distance"]?.ToString();
        }

        public string? GetTime()
        {
            return Response["route"]?["formattedTime"]?.ToString();
        }
    }
}
