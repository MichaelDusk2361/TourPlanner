using TourPlanner.DAL.Repository;
using TourPlanner.Model;

namespace TourPlanner.DAL.Mock
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        private readonly TourPlannerContextMock _context;

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


        public UnitOfWorkMock()
        {
            _context = new TourPlannerContextMock();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool TrySave()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
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
