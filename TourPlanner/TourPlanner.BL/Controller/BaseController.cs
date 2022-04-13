using TourPlanner.BL.MapQuestAPI;
using TourPlanner.Common.Logging;
using TourPlanner.DAL;

namespace TourPlanner.BL.Controller
{
    public abstract class BaseController : IDisposable
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapQuestAPIRequest _mapQuestAPI;
        protected static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

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
                        s_logger.Error("Error during DB save");
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
