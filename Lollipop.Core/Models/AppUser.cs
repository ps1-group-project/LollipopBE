﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Lollipop.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public AppUser() : base()
        {
            
        }
    }
}
