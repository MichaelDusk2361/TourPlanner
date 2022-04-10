using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.MapQuestAPI
{
    internal interface IMapQuestAPIRequest
    {

        public JObject? MapQuestResponse { get; }

        public string From { get; }
        public string To { get; }
        public string TransportMedium { get; }

        public Task ExecuteAsync();

        public Task<byte[]> GetRouteImageAsync();

    }
}
