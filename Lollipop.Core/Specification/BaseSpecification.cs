using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Core.Specification
{
    public class BaseSpecification<T> : IBaseSpecification<T>
        where T : class
    {
        public List<Expression<Func<T, bool>>> FilterBy { get; set; }
        public List<Expression<Func<T, bool>>> OrderBy { get; set; }
        public List<Expression<Func<T, object>>> Include { get; set; }

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Include.Add(includeExpression);
        }

        public void ApplyOrderBy(Expression<Func<T, bool>> orderByExpression)
        {
            OrderBy.Add(orderByExpression);
        }

        public void SetFilterCondition(Expression<Func<T, bool>> filterExpression)
        {
            FilterBy.Add(filterExpression);
        }
    }
}
