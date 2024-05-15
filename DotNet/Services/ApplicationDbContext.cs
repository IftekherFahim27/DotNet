using DotNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Services
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        //Creating Category Table
        public DbSet<Category> Categories { get; set; }

        // For Checking Unique Category Name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Creating Category Table
        public DbSet<Item> Items { get; set; }

    }
}
