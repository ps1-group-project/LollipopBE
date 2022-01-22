using Lollipop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Core.Specification
{
    //usage example GetAllCategories query
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification(List<Expression<Func<Category, bool>>> filterBy = null,
            List<Expression<Func<Category, bool>>> orderBy = null,
            List<Expression<Func<Category, object>>> include = null)
        {
            FilterBy = filterBy ?? new List<Expression<Func<Category, bool>>>();
            OrderBy = orderBy ?? new List<Expression<Func<Category, bool>>>();
            Include = include ?? new List<Expression<Func<Category, object>>>();
        }
    }
}
