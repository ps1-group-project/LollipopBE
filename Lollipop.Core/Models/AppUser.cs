using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lollipop.Core.Models
{
    //here we can put our fields for user
    public class AppUser:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
