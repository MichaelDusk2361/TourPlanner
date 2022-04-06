using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL;

namespace TourPlanner.BL.Controller
{
    public class TourLogController : BaseController
    {

        internal TourLogController(IUnitOfWork uow) : base(uow)
        {
        }



    }
}
