using TourPlanner.DAL.ORM;
using TourPlanner.DAL.Exceptions;
using TourPlanner.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.DAL.Context
{
    public class DBContext : IDBContext
    {
        public Dictionary<ITEntity, EntityState> Entities { get; private set; } = new();

        private readonly NpgsqlConnection _connection;

        public DBContext(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            if (_connection.State != ConnectionState.Open)
                throw new DBConnectionException("connection to DB not open");
        }

        public void LoadTable<TEntity>() where TEntity : class, ITEntity
        {
            var orm = new ObjectRelationalMapper(_connection);
            orm.GetAll<TEntity>().ForEach(item => Entities.Add(item, EntityState.Unchanged));
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

        public void Attach<TEntity>(TEntity entity) where TEntity : class, ITEntity
        {
            Entities.Add(entity, EntityState.Added);
        }

        public void SaveChanges()
        {
            try
            {
                using NpgsqlTransaction transaction = _connection.BeginTransaction();
                var orm = new ObjectRelationalMapper(_connection);
                foreach (var entity in Entities)
                {
                    if (entity.Value == EntityState.Unchanged)
                        continue;

                    if (entity.Value == EntityState.Added)
                        orm.Insert(entity.Key);
                    else if (entity.Value == EntityState.Modified)
                        orm.Update(entity.Key);
                    else if (entity.Value == EntityState.Deleted)
                        orm.Delete(entity.Key);
                }

                transaction.Commit();

                UpdateEntities();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateEntities()
        {
            var keysToDelete = from entity in Entities where entity.Value == EntityState.Deleted select entity.Key;
            keysToDelete.ToList().ForEach(entity => Entities.Remove(entity));
            foreach (var entity in Entities)
            {
                if (entity.Value != EntityState.Unchanged)
                    Entities[entity.Key] = EntityState.Unchanged;
            }
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _connection.Dispose();
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
