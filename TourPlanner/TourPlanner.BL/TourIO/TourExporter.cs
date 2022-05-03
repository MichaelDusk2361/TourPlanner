using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL;
using TourPlanner.Model;

namespace TourPlanner.BL.TourIO
{
    public class TourExporter
    {
        private readonly IUnitOfWork _uow;

        public TourExporter(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Export(string? path)
        {
            if (path == null)
                path = $"ToursPlannerExport_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Guid.NewGuid()}.json";

            var export = (from e in _uow.TourRepository.Get() select new TourToTourLogRelation(e)).ToList();
            foreach (var entity in export)
            {
                entity.TourLogs = _uow.TourLogRepository.Get(tourLog => tourLog.TourId == entity.Id);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(export, Formatting.Indented));
        }
    }
}
