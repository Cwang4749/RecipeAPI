using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RecipeAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace RecipeAPI.Models
{
    public class RecipeAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public RecipeAPIDBContext(DbContextOptions<RecipeAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("RecipeData");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Recipe>()
        //        .HasOne<Nutrition>(s => s.Nutrition)
        //        .WithOne(ad => ad.Recipe)
        //        .HasForeignKey<Recipe>(ad => ad.NutritionID);

        //     modelBuilder.Entity<Nutrition>()
        //        .HasOne<Recipe>(ad => ad.Recipe)
        //        .WithOne(s => s.Nutrition)
        //        .HasForeignKey<Recipe>(ad => ad.NutritionID);
        //}

        public DbSet<Recipe> Recipes { get; set; } = null;
        public DbSet<Nutrition> Nutrition { get; set; } = null;
    }
}

