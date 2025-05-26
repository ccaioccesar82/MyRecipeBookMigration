using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase
{
    public interface IRecipeCreationUseCase
    {
        public Task<RecipeCreationResponseJson> Execute(RecipeCreationAndUpdateRequestJson request);
    }
}
