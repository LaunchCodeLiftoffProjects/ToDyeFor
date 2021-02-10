using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public class ApplicationUserMXRecipe
    {

        public int ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }

        public int MXRecipeId { get; set; }

        public MXRecipe MXRecipe { get; set; }
    }
}