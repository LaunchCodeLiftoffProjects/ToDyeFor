using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDyeFor.Data;
using ToDyeFor.Models;
using ToDyeFor.ViewModel;

namespace ToDyeFor.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private ApplicationDbContext context;
        private List<MXRecipe> mxRecipes;
        private List<MXRecipe> userRecipes;

        public RecipeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            mxRecipes = context.MXRecipes.ToList();
        }

        //get: Recipe
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            userRecipes = mxRecipes.Where(x => x.ApplicationUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(userRecipes);
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
            if (ModelState.IsValid)
            {
                MXRecipe newMXRecipe = new MXRecipe
                {
                    Name = calculateMXRecipeViewModel.Name.ToUpper(),
                    DyeColor = calculateMXRecipeViewModel.DyeColor,
                    ShadeDepth = calculateMXRecipeViewModel.ShadeDepth,
                    FabricWeight = calculateMXRecipeViewModel.FabricWeight,
                    Color = calculateMXRecipeViewModel.Color,
                    Fabric = calculateMXRecipeViewModel.Fabric,
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

            return View(calculateMXRecipeViewModel);
        }

        [HttpGet]
        [Route("Recipe/Delete")]
        public IActionResult Delete()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            userRecipes = mxRecipes.Where(x => x.ApplicationUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(userRecipes);
        }

        [HttpPost]
        [Route("Recipe/Delete")]
        public IActionResult Delete(int[] recipeIds)
        {
            foreach (int recipeId in recipeIds)
            {
                MXRecipe theRecipe = context.MXRecipes.Find(recipeId);
                context.MXRecipes.Remove(theRecipe);
            }
            context.SaveChanges();

            return Redirect("/Recipe");
        }

        //[HttpGet]
        //[Route("Recipe/Detail/{recipeId}")]
        //public IActionResult DeleteDetail(int recipeId)
        //{
        //    MXRecipe theRecipe = context.MXRecipes.Find(recipeId);
        //    context.MXRecipes.Remove(theRecipe);
        //    context.SaveChanges();

        //    return View(theRecipe);
        //}

        [HttpPost]
        [Route("Search/Detail/{recipeId}")]
        public IActionResult DeleteDetail(int recipeId)
        {
            MXRecipe theRecipe = context.MXRecipes.Find(recipeId);
            context.MXRecipes.Remove(theRecipe);
            context.SaveChanges();

            return Redirect("/Recipe");
        }

        //get: Recipe/edit/eventId
        [HttpGet]
        [Route("/Recipe/Edit/{recipeId}")]
        public IActionResult Edit(int recipeId)
        {
            MXRecipe theRecipe= context.MXRecipes.Find(recipeId);

            calculateMXRecipeViewModel editVM = new calculateMXRecipeViewModel
            {
                Id = theRecipe.Id,
                Name = theRecipe.Name,
                DyeColor = theRecipe.DyeColor,
                ShadeDepth = theRecipe.ShadeDepth,
                FabricWeight = theRecipe.FabricWeight,
                Color = theRecipe.Color,
                Fabric = theRecipe.Fabric,
            };

            return View(editVM);
        }

        //processes form
        [HttpPost]
        [Route("/Recipe/Edit")]
        public IActionResult SubmiteditVMForm(calculateMXRecipeViewModel editVM)
        {
            MXRecipe recipeById = context.MXRecipes.Find(editVM.Id);
            recipeById.Name = editVM.Name.ToUpper();
            recipeById.DyeColor = editVM.DyeColor;
            recipeById.ShadeDepth = editVM.ShadeDepth;
            recipeById.FabricWeight = editVM.FabricWeight;
            recipeById.Color = editVM.Color;
            recipeById.Fabric = editVM.Fabric;
            recipeById.Salt = editVM.Salt();
            recipeById.SodaAsh = editVM.SodaAsh();
            recipeById.Water = editVM.Water();
            recipeById.Dye = editVM.Dye();
            context.SaveChanges();
            return Redirect("/Recipe");

        }
    }
}
