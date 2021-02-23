using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDyeFor.Data;
using ToDyeFor.Models;
using ToDyeFor.ViewModel;

namespace ToDyeFor.Controllers
{
    public class RecipeController : Controller
    {
        static private List<MXRecipe> MXRecipes = new List<MXRecipe>();
        private ApplicationDbContext context;
        private List<MXRecipe> mxRecipes;
        

        private readonly UserManager<ApplicationUser> _userManager;
        public RecipeController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            context = dbContext;
            mxRecipes = context.MXRecipes.ToList();
        }


        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //get: Recipe
        public IActionResult Index()
        {
            return View(mxRecipes);
        }

        //retrieves form
        [HttpGet]
        [Route("Recipe/Calculator")]
        public IActionResult Calculator()
        {
            calculateMXRecipeViewModel calculateMXRecipeViewModel = new calculateMXRecipeViewModel();
            return View(calculateMXRecipeViewModel);
        }

        //processes form
        [HttpPost]
        [Route("Recipe/Calculator")]
        public IActionResult Calculator(calculateMXRecipeViewModel calculateMXRecipeViewModel)
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
                Dye = calculateMXRecipeViewModel.Dye(),
                ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
        };
            context.MXRecipes.Add(newMXRecipe);
            context.SaveChanges();
            return Redirect("/Recipe");
        }

        [HttpGet]
        [Route("Recipe/Delete")]
        public IActionResult Delete()
        {
            List<MXRecipe> mxRecipes = new List<MXRecipe>(RecipeData.GetAll());
            return View(mxRecipes);
        }

        [HttpPost]
        [Route("Recipe/Delete")]
        public IActionResult Delete(int[] recipeIds)
        {
            foreach (int recipeId in recipeIds)
            {
                RecipeData.Remove(recipeId);
            }
            return Redirect("/Events");
        }

        //get: Recipe/edit/eventId
        [HttpGet]
        [Route("/Recipe/Edit/{recipeId}")]
        public IActionResult Edit(int recipeId)
        {
            MXRecipe recipeById = RecipeData.GetById(recipeId);
            ViewBag.editRecipe = recipeById;
            ViewBag.title = $"Edit {recipeById.Name}  (id={recipeById.Id})";
            return View();
        }

        //processes form
        [HttpPost]
        [Route("/Recipe/Edit")]
        public IActionResult SubmitEditRecipeForm(int recipeId, string name, string dyeColor)
        {
            MXRecipe recipeById = RecipeData.GetById(recipeId);
            recipeById.Name = name;
            recipeById.DyeColor = dyeColor;
            return Redirect("/Recipe");

        }
    }
}
