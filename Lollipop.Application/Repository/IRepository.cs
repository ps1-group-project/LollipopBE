namespace Lollipop.Application.Repository
{
    using System.Threading.Tasks;

    public interface IRepository<T> //where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
    }
}
