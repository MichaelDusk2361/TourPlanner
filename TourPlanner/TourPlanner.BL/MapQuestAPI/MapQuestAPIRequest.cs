using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Common;

namespace TourPlanner.BL.MapQuestAPI
{
    internal class MapQuestApiRequest : IMapQuestAPIRequest
    {

        private JObject? _mapQuestResponse = null;
        public string From { get; set; }
        public string To { get; set; }
        public string TransportMedium { get; set; }

        public MapQuestApiRequest(string from, string to, string transportMedium)
        {
            From = from;
            To = to;
            TransportMedium = transportMedium;
        }


        public async Task ExecuteAsync()
        {
            try
            {
                using var client = new HttpClient();
                var key = ConfigFile.AppSettings("MapQuestApiKey");
                //there is the key, from, to, unit, routeType (transport medium )
                var stringTask = client.GetStringAsync("http://www.mapquestapi.com/directions/v2/route?key=bCbFfaipCaFRgjR3va8yWTqkn5HESfQJ&from=Clarendon%20Blvd,Arlington,VA&to=2400%20S%20Glebe%20Rd,%20Arlington,%20VA&unit=k&routeType=pedestrian");
                var msg = await stringTask;

                var res = JsonConvert.DeserializeObject<JObject>(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
