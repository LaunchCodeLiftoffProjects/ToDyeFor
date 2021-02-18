﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RecipeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            mxRecipes = context.MXRecipes.ToList();
        }
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
                Color = calculateMXRecipeViewModel.Color,
                Fabric = calculateMXRecipeViewModel.Fabric,
                Salt = calculateMXRecipeViewModel.Salt(),
                SodaAsh = calculateMXRecipeViewModel.SodaAsh(),
                Water = calculateMXRecipeViewModel.Water(),
                Dye = calculateMXRecipeViewModel.Dye()
            };
            context.MXRecipes.Add(newMXRecipe);
            context.SaveChanges();
            return Redirect("/Recipe");
        }

        [HttpGet]
        [Route("Recipe/Delete")]
        public IActionResult Delete()
        {
            return View(mxRecipes);
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

        //get: Recipe/edit/eventId
        [HttpGet]
        [Route("/Recipe/Edit/{recipeId}")]
        public IActionResult Edit(int recipeId)
        {
            MXRecipe theRecipe= context.MXRecipes.Find(recipeId);
            //ViewBag.editRecipe = theRecipe;
            //ViewBag.title = $"Edit {recipeById.Name}  (id={recipeById.Id})";
            return View(theRecipe);
        }

        //processes form
        [HttpPost]
        [Route("/Recipe/Edit")]
        public IActionResult SubmitEditRecipeForm(int recipeId, string name, string dyeColor)
        {
            MXRecipe recipeById = context.MXRecipes.Find(recipeId);
            recipeById.Name = name;
            recipeById.DyeColor = dyeColor;
            context.SaveChanges();
            return Redirect("/Recipe");

        }
    }
}
