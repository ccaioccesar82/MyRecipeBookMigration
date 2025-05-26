using Mapster;
using MyRecipeBook.Application.UseCases.Interfaces.DashBoardUseCase;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;

namespace MyRecipeBook.Application.UseCases.DashBoardUseCases
{
    public class DashBoardUseCase : IDashBoardUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IRecipeReadOnlyRepository _readOnly;

        public DashBoardUseCase(ILoggedUser loggedUser, IRecipeReadOnlyRepository readOnly)
        {
            _loggedUser = loggedUser;
            _readOnly = readOnly;
        }



        public async Task<RecipeListResponseJson> Execute()
        {
            var user = await _loggedUser.FindUserByToken();

            var recipeList = await _readOnly.RecipesToDashboard(user.Id);

            var listReponse = recipeList.Adapt<IList<RecipeShortResponseJson>>();

            return new RecipeListResponseJson
            {

                Recipes = listReponse,
            };
        }
    }
}
