using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.RecipeRepository
{
    public class RecipeWriteOnlyRepository(MyRecipeBookDbContext dbContext) : IRecipeWriteOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext = dbContext;


        public void DeleteRecipe(Recipe recipe) => _dbContext.Recipes.Remove(recipe);


        public async Task CreateRecipe(Recipe recipe)=>  await _dbContext.AddAsync(recipe);

        public void UpdateRecipe(Recipe recipe) => _dbContext.Recipes.Update(recipe);

    }
}
