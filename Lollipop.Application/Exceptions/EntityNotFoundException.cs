using System;

namespace Lollipop.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, string id)
            : base($"Entity of type {type} and id {id} was not found.")
        {
        }
    }
}
