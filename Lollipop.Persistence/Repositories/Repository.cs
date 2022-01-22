namespace Lollipop.Persistence.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Lollipop.Application.Repository;
    using Lollipop.Persistence.DbContext;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System;
    using Lollipop.Persistence.Services;
    using Lollipop.Core.Specification;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LollipopDbContext _dbContext;

        private DbSet<T> DbSet => _dbContext.Set<T>();

        public Repository(LollipopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll(IBaseSpecification<T> specification = null) =>
            SpecificationEvaluator<T>.GetEvaluatedQuery(DbSet, specification).ToList();

        public Task<List<T>> GetAllAsync(IBaseSpecification<T> specification = null) =>
            SpecificationEvaluator<T>.GetEvaluatedQuery(DbSet, specification).ToListAsync();

        public int GetCount(IBaseSpecification<T> specification = null)
        {
            return SpecificationEvaluator<T>.GetEvaluatedQuery(DbSet, specification).Count();
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
