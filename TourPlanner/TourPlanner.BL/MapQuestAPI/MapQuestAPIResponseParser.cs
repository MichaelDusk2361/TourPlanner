using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestAPIResponseParser
    {
        public JObject Response { get; private set; }

        public MapQuestAPIResponseParser(JObject response)
        {
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
