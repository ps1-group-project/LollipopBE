namespace Lollipop.Persistence.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Lollipop.Application.Repository;
    using Lollipop.Persistence.DbContext;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LollipopDbContext _dbContext;

        private DbSet<T> DbSet => _dbContext.Set<T>();

        public Repository(LollipopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = DbSet.Add(entity);
            await _dbContext.SaveChangesAsync();

            return addedEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null) return;

            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return _dbContext.Entry(entity).Entity;
        }
    }
}
