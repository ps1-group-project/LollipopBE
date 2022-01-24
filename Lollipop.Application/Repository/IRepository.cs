namespace Lollipop.Application.Repository
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System;
    using System.Linq.Expressions;
    using System.Linq;
    using Lollipop.Core.Specification;

    public interface IRepository<T>
    {

        List<T> GetAll(IBaseSpecification<T> specification = null);
        int GetCount(IBaseSpecification<T> specification = null);
        Task<List<T>> GetAllAsync(IBaseSpecification<T> specification = null);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);

    }
}
