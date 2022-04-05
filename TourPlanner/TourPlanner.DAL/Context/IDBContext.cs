using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.DAL.Context
{
    public interface IDBContext : IDisposable
    {
        public Dictionary<ITEntity, EntityState> Entities { get; }

        public void LoadTable<TEntity>() where TEntity : class, ITEntity;

        public DBTable<TEntity> Table<TEntity>() where TEntity : class, ITEntity;

        public void Attach<TEntity>(TEntity entity) where TEntity : class, ITEntity;

        public void SaveChanges();

    }
}
