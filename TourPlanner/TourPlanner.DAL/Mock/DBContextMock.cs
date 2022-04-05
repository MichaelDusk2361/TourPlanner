using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL.Context;
using TourPlanner.DAL.Mock;
using TourPlanner.Model;

namespace TourPlanner.DAL.Mock
{
    public class DBContextMock : IDBContext
    {
        public Dictionary<ITEntity, EntityState> Entities { get; private set; } = new();

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class, ITEntity
        {
            Entities.Add(entity, EntityState.Added);
        }

        public void LoadTable<TEntity>() where TEntity : class, ITEntity
        {
            var data = DBMock.GetMockData<TEntity>();
            data.ForEach(item => Entities.Add(item, EntityState.Unchanged));
        }

        public DBTable<TEntity> Table<TEntity>() where TEntity : class, ITEntity
        {
            var res = new List<TEntity>();
            foreach (var entity in Entities.Keys)
            {
                if (entity.GetType() == typeof(TEntity))
                    res.Add(entity as TEntity);
            }
            return new(res);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
