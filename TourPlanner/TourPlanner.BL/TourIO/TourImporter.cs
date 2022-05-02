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
    public class TourImporter
    {

        private readonly IUnitOfWork _uow;

        public TourImporter(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public void Import(string path)
        {
            var fileString = File.ReadAllText(path);
            var import = JsonConvert.DeserializeObject<List<TourToTourLogRelation>>(fileString);
            var allToursInFile = (from tourToTourLogRelation in import select new Tour(tourToTourLogRelation)).ToList();
            var allTourLogsInFile = (from tourToTourLogRelation in import select tourToTourLogRelation.TourLogs).SelectMany(i => i).ToList();
            //all that are not in db, put in db
            var allToursInDB = _uow.TourRepository.Get();
            var allTourLogsInDB = _uow.TourLogRepository.Get();
            var toursToImport = (from tour in allToursInFile where !allToursInDB.Any(i => i.Id == tour.Id) select tour).ToList();
            var tourLogsToImport = (from tourLog in allTourLogsInFile where !allTourLogsInDB.Any(i => i.Id == tourLog.Id) select tourLog).ToList();

            toursToImport.ForEach(tour => _uow.TourRepository.Insert(tour));
            tourLogsToImport.ForEach(tourLog => _uow.TourLogRepository.Insert(tourLog));
        }
    }
}
