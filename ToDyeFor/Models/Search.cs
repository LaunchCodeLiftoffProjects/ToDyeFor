using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace ToDyeFor.Models
{
   public class RecipeSearchModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public IPagedList<MXRecipe> SearchResult { get; set; }
        public string ColorType { get; set; }
        public int DepthOfShade { get; set; }
        public string SearchButton { get; set; }

    }
}
