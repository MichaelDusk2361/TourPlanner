using TourPlanner.Common.Logging;
using TourPlanner.DAL.Context;
using TourPlanner.DAL.Repository;
using TourPlanner.Model;

namespace TourPlanner.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TourPlannerContext _context;
        private static readonly Semaphore s_semaphore = new(1, 1);

        private static readonly ILoggerWrapper s_logger = LoggerFactory.GetLogger();

        private GenericRepository<Tour>? _tourRepository = null;
        public GenericRepository<Tour> TourRepository
        {
            get
            {
                if (_tourRepository == null)
                    _tourRepository = new GenericRepository<Tour>(_context);
                return _tourRepository;
            }
        }

        private GenericRepository<TourLog>? _tourLogRepository = null;
        public GenericRepository<TourLog> TourLogRepository
        {
            get
            {
                if (_tourLogRepository == null)
                    _tourLogRepository = new GenericRepository<TourLog>(_context);
                return _tourLogRepository;
            }
        }


        public UnitOfWork()
        {
            try
            {
                s_semaphore.WaitOne();
                _context = new TourPlannerContext();
            }
            finally
            {
                s_semaphore.Release();
            }
        }

        public void Save()
        {
            try
            {
                s_semaphore.WaitOne();
                _context.SaveChanges();
            }
            finally
            {
                s_semaphore.Release();
            }
        }

        public bool TrySave()
        {
            try
            {
                Save();
            }
            catch (Exception e)
            {
                s_logger.Error($"exception during db save {e}");
                return false;
            }
            return true;
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
