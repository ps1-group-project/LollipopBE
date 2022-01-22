using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Lollipop.Core.Specification
{

    public interface IBaseSpecification<T>
    {
        public List<Expression<Func<T, bool>>> FilterBy { get; set; }

        public List<Expression<Func<T, bool>>> OrderBy { get; set; }

        public List<Expression<Func<T, object>>> Include { get; set; }
    }
}
