using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.DAL;

namespace TourPlanner.BL.Controller
{
    public class TourLogController : BaseController
    {

        internal TourLogController(IUnitOfWork uow, IMapQuestAPIRequest mapQuestAPI) : base(uow, mapQuestAPI)
        {
        }



    }
}
