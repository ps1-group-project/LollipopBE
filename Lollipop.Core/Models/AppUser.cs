using System;
using Microsoft.AspNetCore.Identity;

namespace Lollipop.Core.Models
{
    public class AppUser:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
