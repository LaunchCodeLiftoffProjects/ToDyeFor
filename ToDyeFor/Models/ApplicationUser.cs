using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<string> UserMXRecipes { get; set; }
        
        //public string Picture { get; set; }

        //public string Bio { get; set; }
    }
}
