using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // used this article to help me figure this out: https://www.koskila.net/how-to-add-creator-modified-info-to-all-of-your-ef-models-at-once-in-net-core/
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is MXRecipe && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((MXRecipe)entity.Entity).CreatedDate = DateTime.UtcNow;
                }
             ((MXRecipe)entity.Entity).UpdatedDate = DateTime.UtcNow;
            }
        }
    }

}
