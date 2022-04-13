using System.Collections;
using System.Linq.Expressions;
using TourPlanner.Model;

namespace TourPlanner.DAL.Context
{
    public class DBTable<TEntity> : IQueryable<TEntity> where TEntity : class, ITEntity
    {

        public List<TEntity> Entities { get; private set; } = new();

        public DBTable(List<TEntity> entities)
        {
            Entities = entities;
        }

        public TEntity? Find(Guid id)
        {
            foreach (var entity in Entities)
            {
                if (entity.Id == id)
                    return entity;
            }
            return null;
        }

        public void Update(TEntity entityToUpdate)
        {
            var destination = Find(entityToUpdate.Id);
            if (destination == null)
                return;
            var sourceProperties = typeof(TEntity).GetProperties();
            foreach (var sourceProp in sourceProperties)
            {
                var targetProp = entityToUpdate.GetType().GetProperty(sourceProp.Name);
                targetProp?.SetValue(destination, sourceProp.GetValue(entityToUpdate, null), null);
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            Entities.Remove(entityToDelete);
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public Type ElementType => Entities.AsQueryable().ElementType;

        public Expression Expression => Entities.AsQueryable().Expression;

        public IQueryProvider Provider => Entities.AsQueryable().Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Entities.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Entities.AsQueryable().GetEnumerator();
        }
    }
}
