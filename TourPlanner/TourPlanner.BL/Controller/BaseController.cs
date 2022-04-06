using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL;

namespace TourPlanner.BL.Controller
{
    public abstract class BaseController : IDisposable
    {
        protected readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
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
