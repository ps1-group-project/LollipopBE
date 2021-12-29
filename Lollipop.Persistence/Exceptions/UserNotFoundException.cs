using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Persistence.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string _message { get; set; }
        public int _statusCode { get; set; }
        public UserNotFoundException(string message, int statusCode=500) : base(message)
        {
            _message = message;
            _statusCode = statusCode;
        }
    }
}
