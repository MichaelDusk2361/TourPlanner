using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TourPlanner.BL
{
    public class Class1
    {

        public static async void RunAsync()
        {
            var client = new HttpClient();

            //https://developer.mapquest.com/documentation/open/directions-api/route/get
            //there is the key, from, to, unit, routeType (transport medium )
            var stringTask = client.GetStringAsync("http://www.mapquestapi.com/directions/v2/route?key=bCbFfaipCaFRgjR3va8yWTqkn5HESfQJ&from=Clarendon%20Blvd,Arlington,VA&to=2400%20S%20Glebe%20Rd,%20Arlington,%20VA&unit=k&routeType=pedestrian");
            var msg = await stringTask;

            var res = JsonConvert.DeserializeObject<JObject>(msg);
            Console.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Console.WriteLine(res?["route"]?["distance"]);
            //Unhandled exception. System.Net.Http.HttpRequestException: Response status code does not indicate success: 403 (Forbidden). if key is wrong



            //if needed parameters for model are there treat it as a sucess if not give some sort of feedback 
            //if one from or to are missing
            //{
            //    "route": {
            //        "routeError": {
            //            "errorCode": 211,
            //            "message": ""
            //            }
            //    },
            //    "info": {
            //        "statuscode": 611,
            //        "copyright": {
            //            "imageAltText": "© 2022 MapQuest, Inc.",
            //            "imageUrl": "http://api.mqcdn.com/res/mqlogo.gif",
            //            "text": "© 2022 MapQuest, Inc."
            //            },
            //        "messages": [
            //            "At least two locations must be provided."
            //            ]
            //        }
            //}


            //write a class to parse response, and one to make the response
            //we also need a model containing the sessing id and the bounds for the map
        }
    }
}
