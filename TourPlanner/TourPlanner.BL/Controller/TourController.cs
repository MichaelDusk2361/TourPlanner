using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL;
using TourPlanner.Model;

namespace TourPlanner.BL.Controller
{
    public class TourController : IDisposable
    {
        private readonly IUnitOfWork _uow;

        internal TourController(IUnitOfWork uow)
        {
            //where will the save function be called?
            _uow = uow;
        }

        public List<Tour> GetAllTours()
        {
            return _uow.TourRepository.Get();
        }

        public void UpdateTour(Tour tour)
        {
            _uow.TourRepository.Update(tour);
        }

        #region IDisposable
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _uow.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
