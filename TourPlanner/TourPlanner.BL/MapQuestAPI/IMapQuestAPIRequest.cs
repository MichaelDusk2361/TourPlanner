using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.MapQuestAPI
{
    public interface IMapQuestAPIRequest
    {
        public JObject? MapQuestResponse { get; }

        public Task ExecuteAsync(string from, string to, string transportMedium);

        public Task<byte[]> GetRouteImageAsync();
    }
}
