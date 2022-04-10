using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestAPIRequestMock : IMapQuestAPIRequest
    {
        public JObject? MapQuestResponse { get; private set; } = null;

        public Task ExecuteAsync(string from = "Clarendon Blvd,Arlington,VA", string to = "2400 S Glebe Rd, Arlington, VA", string transportMedium = "pedestrian")
        {
            var jsonString = @"{""route"":{ ""hasTollRoad"":false,""hasBridge"":false,""boundingBox"":{ ""lr"":{ ""lng"":-77.08123,""lat"":38.848927},""ul"":{ ""lng"":-77.091591,""lat"":38.888844} },""distance"":4.923,""hasTimedRestriction"":false,""hasTunnel"":false,""hasHighway"":false,""computedWaypoints"":[],""routeError"":{ ""errorCode"":-400,""message"":""""},""formattedTime"":""01:13:23"",""sessionId"":""62531d4b-016d-6750-02b4-34e8-0e25bc0acdcf"",""hasAccessRestriction"":false,""realTime"":4403,""hasSeasonalClosure"":false,""hasCountryCross"":false,""fuelUsed"":0}";
            MapQuestResponse = JsonConvert.DeserializeObject<JObject>(jsonString);
            return Task.CompletedTask;
        }

        public Task<byte[]> GetRouteImageAsync()
        {
            if (MapQuestResponse == null)
                throw new InvalidOperationException("Image cant be fetched before route data has been received");

            return Task.FromResult(Array.Empty<byte>());
        }
    }
}
