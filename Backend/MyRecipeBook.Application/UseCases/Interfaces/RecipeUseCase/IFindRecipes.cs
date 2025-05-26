using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase
{
    public interface IFindRecipes
    {
        public Task<RecipeListResponseJson> FilterRecipe(RecipeFilterRequestJson request);

        public Task<RecipeResponseJson> FindRecipe(Guid recipeId);
    }
}
