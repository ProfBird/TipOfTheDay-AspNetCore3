using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipOfTheDay_Core3.Models
{
    public class AppUser : IdentityUser
    {
        public String FullName { get; set; }
    }
}
