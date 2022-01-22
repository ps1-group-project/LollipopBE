using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lollipop.Core;
using Lollipop.Core.Models;
using Lollipop.Core.Specification;

namespace Lollipop.Persistence.Services
{
    public static class SpecificationEvaluator<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Evaluate query by specification
        /// </summary>
        /// <param name="entities">TEntity Query</param>
        /// <param name="specification">IBaseSpecification</param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetEvaluatedQuery(IQueryable<TEntity> entities, IBaseSpecification<TEntity> specification)
        {
            if (specification is null)
                return entities;

            if (specification.Include is not null && specification.Include.Any())
                entities = specification.Include.Aggregate(entities, (current, include) => current.Include(include));

            if (specification.FilterBy is not null && specification.FilterBy.Any())
                entities = specification.FilterBy.Aggregate(entities, (current, filter) => current.Where(filter));

            if (specification.OrderBy is not null && specification.OrderBy.Any())
                entities = specification.OrderBy.Aggregate(entities, (current, orderBy) => current.OrderBy(orderBy));

            return entities;
        }
    }
}
