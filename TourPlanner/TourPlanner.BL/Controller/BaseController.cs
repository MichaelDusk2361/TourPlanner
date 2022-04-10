using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.MapQuestAPI;
using TourPlanner.DAL;

namespace TourPlanner.BL.Controller
{
    public abstract class BaseController : IDisposable
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapQuestAPIRequest _mapQuestAPI;

        public BaseController(IUnitOfWork uow, IMapQuestAPIRequest mapQuestAPI)
        {
            _uow = uow;
            _mapQuestAPI = mapQuestAPI;
        }

        #region IDisposable
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (!_uow.TrySave())
                    {
                        Console.WriteLine("Error during DB save");
                    }
                    _uow.Dispose();
                }
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
