using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Entities.UserEntities;

namespace MyRecipeBook.Infrastructure.DataAccess
{
    public class MyRecipeBookDbContext: DbContext
    {


        public MyRecipeBookDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishType> DishTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
        }

    }
}
