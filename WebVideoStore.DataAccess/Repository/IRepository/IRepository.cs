namespace WebVideoStore.DataAccess.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        // T- Category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);

        void Remove(T enity);

        void RemoveRange(IEnumerable<T> entity);
    }
}
