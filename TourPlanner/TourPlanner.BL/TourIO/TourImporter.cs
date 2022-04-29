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
            //filter and store to db
        }
    }
}
