using TourPlanner.DAL.Context;
using TourPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.DAL.Repository {
    public class GenericRepository<TEntity> where TEntity : class, ITEntity
    {
        private readonly IDBContext _context;
        private readonly DBTable<TEntity> _table;

        public GenericRepository(IDBContext context) {
            _context = context;
            _table = context.Table<TEntity>();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null) {

            IQueryable<TEntity> query = _table;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public TEntity GetById(Guid id) {
            return _table.Find(id);
        }

        public void Insert(TEntity entity) {
            _context.Attach(entity);
            _table.Add(entity);
        }

        public void Delete(Guid id) {
            TEntity entityToDelete = _table.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete) {
            _context.Entities[entityToDelete] = EntityState.Deleted;
            _table.Delete(entityToDelete);
        }

        public void Update(TEntity entityToUpdate) {
            _context.Entities[entityToUpdate] = EntityState.Modified;
            _table.Update(entityToUpdate);
        }
    }
}
