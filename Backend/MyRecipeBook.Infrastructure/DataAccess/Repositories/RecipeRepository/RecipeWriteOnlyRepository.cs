using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.RecipeRepository
{
    public class RecipeWriteOnlyRepository : IRecipeWriteOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public RecipeWriteOnlyRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateRecipe(Recipe recipe)
        {
            await _dbContext.AddAsync(recipe);

        }
    }
}
