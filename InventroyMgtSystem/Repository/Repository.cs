using InventroyMgtSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Repository
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        internal DbSet<T> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            this._dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public T Get(int id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFisrtOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Remove(int id)
        {
            var obj = _dbset.Find(id);
            Remove(obj);
        }

        public void RemoveRange(IEnumerable<T> entityList)
        {
            _dbset.RemoveRange(entityList);
        }
    }
}
