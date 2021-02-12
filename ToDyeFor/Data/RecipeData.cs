using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDyeFor.Models;

namespace ToDyeFor.Data
{
    public class RecipeData
    {
        static private Dictionary<int, MXRecipe> MXRecipes = new Dictionary<int, MXRecipe>();

        // GetAll
        public static IEnumerable<MXRecipe> GetAll()
        {
            return MXRecipes.Values;
        }

        // Add
        public static void Add(MXRecipe newMXRecipe)
        {
            MXRecipes.Add(newMXRecipe.Id, newMXRecipe);
        }

        // Remove
        public static void Remove(int id)
        {
            MXRecipes.Remove(id);
        }

        // GetById
        public static MXRecipe GetById(int id)
        {
            return MXRecipes[id];
        }
    }
}
