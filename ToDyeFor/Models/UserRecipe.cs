using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public class UserRecipe
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public  int  MXRecipeId { get; set; }

        public MXRecipe MXRecipe { get; set; }
    }
}
