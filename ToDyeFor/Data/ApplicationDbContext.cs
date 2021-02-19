using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDyeFor.Models;

namespace ToDyeFor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
               
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MXRecipe> MXRecipes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
