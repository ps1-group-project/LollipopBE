namespace Lollipop.Application.Repository
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System;
    using System.Linq.Expressions;
    using System.Linq;

    public interface IRepository<T> //where T : class
    {
        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
    }
}
