using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDyeFor.Data;
using ToDyeFor.Models;
using ToDyeFor.ViewModel;

namespace ToDyeFor.Controllers
{
    public class HomeController : Controller
    {

        static private List<MXRecipe> MXRecipes = new List<MXRecipe>();


        [HttpGet]
        public IActionResult Index()
        {
            calculateMXRecipeViewModel calculateMXRecipeViewModel = new calculateMXRecipeViewModel();
            return View(calculateMXRecipeViewModel);
        }

        [HttpPost]
        [Route("Home/Results")]
        public IActionResult Index(calculateMXRecipeViewModel calculateMXRecipeViewModel)
        {
            MXRecipe newMXRecipe = new MXRecipe
            {
                Name = calculateMXRecipeViewModel.Name,
                DyeColor = calculateMXRecipeViewModel.DyeColor,
                ShadeDepth = calculateMXRecipeViewModel.ShadeDepth,
                FabricWeight = calculateMXRecipeViewModel.FabricWeight,
                Salt = calculateMXRecipeViewModel.Salt(),
                SodaAsh = calculateMXRecipeViewModel.SodaAsh(),
                Water = calculateMXRecipeViewModel.Water(),
                Dye = calculateMXRecipeViewModel.Dye()
            };
            RecipeData.Add(newMXRecipe);

            return Redirect("/Home/Results");
        }

        public IActionResult Results()
        {
            List<MXRecipe> mxRecipes = new List<MXRecipe>(RecipeData.GetAll());

            return View(mxRecipes);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
