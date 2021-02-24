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

        private List<MXRecipe> mxRecipes;



        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            mxRecipes = context.MXRecipes.ToList();
        }

        public IActionResult Index()
        {
            //ViewBag.displayRecipes = null;
            return View();
        }

        //[HttpPost]
        //[Route("Search/Index")]
        public IActionResult Results(string searchInput)
        {
            List<MXRecipe> displayRecipes = new List<MXRecipe>();
            if (string.IsNullOrEmpty(searchInput))
            {
                displayRecipes = mxRecipes;
            }
            else
            {
                string lowercaseTerm = searchInput.ToLower();
                foreach (MXRecipe r in mxRecipes)
                {
                    if (r.Name.ToLower().Contains(lowercaseTerm))
                    {
                        displayRecipes.Add(r);
                    }else if (r.DyeColor.ToLower().Contains(lowercaseTerm))
                    {
                        displayRecipes.Add(r);
                    }else if (r.Color.ToString().ToLower().Contains(lowercaseTerm))
                    {
                        displayRecipes.Add(r);
                    }
                }
                //string lowercaseTerm = searchTerm.ToLower();
                //displayRecipes.AddRange(mxRecipes
                //    .Where(r => r.Color.ToString().ToLower()
                //    .Contains(searchTerm)).ToList());
                //displayRecipes.AddRange(mxRecipes
                //    .Where(r => r.DyeColor.ToString().ToLower()
                //    .Contains(searchTerm)).ToList());
                //displayRecipes.AddRange(mxRecipes
                //    .Where(r => r.Name.ToString().ToLower()
                //    .Contains(searchTerm)).ToList());
            }
            ViewBag.displayRecipes = displayRecipes;
            return View("Index");
         }
    }
}
