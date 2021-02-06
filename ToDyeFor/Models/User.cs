using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRecipe> UserRecipes { get; set; }
        
        //public string Picture { get; set; }

        //public string Bio { get; set; }
    }
}
