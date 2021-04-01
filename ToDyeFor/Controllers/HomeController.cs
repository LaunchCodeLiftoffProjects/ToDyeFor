using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDyeFor.Data;
using ToDyeFor.Models;
using ToDyeFor.ViewModel;

namespace ToDyeFor.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;


        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        //js calculator
        public IActionResult Index()
        {
            CalculateMXRecipeViewModel calculateMXRecipeViewModel = new CalculateMXRecipeViewModel();
            return View(calculateMXRecipeViewModel);
        }

        [HttpPost]
        [Authorize]
        //[Route("Home/Results")]
        public IActionResult Index(CalculateMXRecipeViewModel calculateMXRecipeViewModel)
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
