using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.DashBoardUseCase
{
    public interface IDashBoardUseCase
    {
        public Task<RecipeListResponseJson> Execute();
    }
}
