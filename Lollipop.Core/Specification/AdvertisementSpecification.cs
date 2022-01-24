using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lollipop.Core.Models;
using Lollipop.Core;

namespace Lollipop.Core.Specification
{
    //all other classes will look similar, just different type
    public class AdvertisementSpecification : BaseSpecification<Advertisement>
    {
        public AdvertisementSpecification(List<Expression<Func<Advertisement, bool>>> filterBy = null,
            List<Expression<Func<Advertisement, bool>>> orderBy = null,
            List<Expression<Func<Advertisement, object>>> include = null)
        {
            FilterBy = filterBy ?? new List<Expression<Func<Advertisement, bool>>>();
            OrderBy = orderBy ?? new List<Expression<Func<Advertisement, bool>>>();
            Include = include ?? new List<Expression<Func<Advertisement, object>>>();
        }
    }
}
