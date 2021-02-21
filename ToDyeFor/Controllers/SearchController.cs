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

        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Results(string searchTerm)
        {
            
            List<MXRecipe> recipe;
            if (string.IsNullOrEmpty(searchTerm))
            {
                recipe = context.Recipes
                    .Include(j => j.Name)
                    .ToList();

            }
            return View("Index");
        }
    }
}
