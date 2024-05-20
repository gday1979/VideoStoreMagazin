namespace WebVideoStore.DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebVideoStore.DataAccess.Data;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using System.Linq.Expressions;

    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.VideoTapes.Include(u => u.Category).Include(u=>u.CategoryId);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }
        //Category,CategoryId
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query=query.Where(filter);
            }
           if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProperty in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            
            return query.ToList();
        }

        public void Remove(T enity)
        {
           dbSet.Remove(enity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
