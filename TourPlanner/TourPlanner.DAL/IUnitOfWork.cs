using TourPlanner.DAL.Repository;
using TourPlanner.Model;

namespace TourPlanner.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Tour> TourRepository { get; }
        GenericRepository<TourLog> TourLogRepository { get; }
        void Save();
        bool TrySave();
    }
}
