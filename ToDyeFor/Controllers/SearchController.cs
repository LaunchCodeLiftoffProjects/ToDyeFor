using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDyeFor.Models;
using ToDyeFor.Data;
using Microsoft.EntityFrameworkCore;
using ToDyeFor.ViewModel;

namespace ToDyeFor.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext context;

        //private List<MXRecipe> mxRecipes;



        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //ViewBag.displayRecipes = null;
            return View();
        }

        //[HttpPost]
        //[Route("Search/Index")]
        public IActionResult Results(string searchTerm)
        {
            List<MXRecipe> displayRecipes = new List<MXRecipe>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                displayRecipes = context.MXRecipes.ToList();
            }
            else
            {
                displayRecipes.AddRange(context.MXRecipes.ToList()
                    .Where(r => r.Color.ToString()
                    .Contains(searchTerm)).ToList());
            }
            ViewBag.displayRecipes = displayRecipes;
            return View("Index");
        }
    }
}
