using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public List<MXRecipe> UserMXRecipes { get; set; }

        //public string Picture { get; set; }

        //public string Bio { get; set; }
    }
}
