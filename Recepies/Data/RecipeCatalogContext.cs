using Microsoft.EntityFrameworkCore;
using Recipes.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace Recipes.Data
{
    public class RecipeCatalogContext : DbContext
    {
        public RecipeCatalogContext(DbContextOptions<RecipeCatalogContext> options) : base(options){}
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Предястие" },
                new Category { CategoryId = 2, Name = "Основно" },
                new Category { CategoryId = 3, Name = "Десерт" }
            );

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<RecipeIngredient>()
                .Property(ri => ri.Quantity)
                .HasPrecision(18, 4);
        }
    }
}
