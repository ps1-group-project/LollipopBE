using System;
using Microsoft.AspNetCore.Identity;

namespace Lollipop.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public AppUser() : base()
        {

        }
    }
}
