using TourPlanner.DAL.Context;
using TourPlanner.DAL.Exceptions;
using TourPlanner.DAL.Repository;
using TourPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TourPlanner.DAL
{
    public class UnitOfWork : IDisposable
    {

        private readonly TourPlannerContext _context;
        private static readonly Semaphore s_semaphore = new(1, 1);

        private readonly Lazy<GenericRepository<Tour>> _tourRepository;
        public GenericRepository<Tour> TourRepository
        {
            get
            {
                return _tourRepository.Value;
            }
        }

        private readonly Lazy<GenericRepository<TourLog>> _tourLogRepository;
        public GenericRepository<TourLog> TourLogRepository
        {
            get
            {
                return _tourLogRepository.Value;
            }
        }

        public UnitOfWork()
        {
            try
            {
                s_semaphore.WaitOne();
                _context = new TourPlannerContext();
                //after context is initialized, initialize all repositories
                _tourRepository = new Lazy<GenericRepository<Tour>>(new GenericRepository<Tour>(_context));
                _tourLogRepository = new Lazy<GenericRepository<TourLog>>(new GenericRepository<TourLog>(_context));
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
                Console.WriteLine(e);
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
