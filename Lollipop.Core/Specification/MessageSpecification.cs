using Lollipop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Core.Specification
{
    public class MessageSpecification : BaseSpecification<Message>
    {
        public MessageSpecification(List<Expression<Func<Message, bool>>> filterBy = null,
            List<Expression<Func<Message, bool>>> orderBy = null,
            List<Expression<Func<Message, object>>> include = null)
        {
            FilterBy = filterBy ?? new List<Expression<Func<Message, bool>>>();
            OrderBy = orderBy ?? new List<Expression<Func<Message, bool>>>();
            Include = include ?? new List<Expression<Func<Message, object>>>();
        }
    }
}
