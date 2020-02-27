﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipOfTheDay.Models
{
    public class AppUser : IdentityUser
    {
        public String FullName { get; set; }
    }
}
