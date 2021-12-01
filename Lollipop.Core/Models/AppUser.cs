using System;
using Microsoft.AspNet.Identity.EntityFramework;

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
