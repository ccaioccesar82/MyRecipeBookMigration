using MyRecipeBook.Domain.Entities.RecipeEntities;

namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes
{
    public interface IRecipeWriteOnlyRepository
    {
        public Task CreateRecipe(Recipe recipe);

        public void DeleteRecipe(Recipe recipe);
    }
}
