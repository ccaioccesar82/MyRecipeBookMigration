using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.Recipe
{
    public interface IRecipeCreationUseCase
    {
        public Task<RecipeCreationResponseJson> Execute(RecipeRequestJson request);
    }
}
