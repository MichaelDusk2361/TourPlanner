using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL;
using TourPlanner.Model;

namespace TourPlanner.BL.Controller
{
    public class TourController : BaseController
    {
        internal TourController(IUnitOfWork uow) : base(uow)
        {
        }

        public List<Tour> GetAllTours()
        {
            return _uow.TourRepository.Get();
        }

        public void DeleteTour(Tour tour)
        {
            _uow.TourRepository.Delete(tour);
        }

        public void AddTour(Tour tour)
        {
            _uow.TourRepository.Insert(tour);
        }

        public void UpdateTour(Tour tour)
        {
            _uow.TourRepository.Update(tour);
        }
    }
}
