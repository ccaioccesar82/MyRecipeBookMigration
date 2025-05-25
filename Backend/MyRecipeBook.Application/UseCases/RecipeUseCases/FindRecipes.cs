using Mapster;
using MapsterMapper;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Domain.DTO;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class FindRecipes : IFindRecipes
    {

        private readonly IRecipeReadOnlyRepository _readOnly;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public FindRecipes(IRecipeReadOnlyRepository readOnly, 
            ILoggedUser loggedUser,
            IMapper mapper)
        {
            _readOnly = readOnly;
            _loggedUser = loggedUser;
            _mapper = mapper;
        }


        public async Task<IList<RecipeFilteredResponseJson>> FilterRecipe(RecipeFilterRequestJson request)
        {
            //pega o userid
            var user = await _loggedUser.FindUserByToken();

            var filter = request.Adapt<FilterRecipeDTO>();

            var result = await _readOnly.FilterRecipes(user.Id, filter);

            var listReponse = result.Adapt<IList<RecipeFilteredResponseJson>>();

            return listReponse;
        }


        public async Task<RecipeResponseJson> FindRecipe(Guid recipeId)
        {
            var user = await _loggedUser.FindUserByToken();

            var recipeResult = await _readOnly.FindRecipeById(recipeId, user.Id);

            if (recipeResult == null)
            {
                throw new NotFoundException(ResourceMessageException.NOT_FOUND_ERROR);
            }

            var response = recipeResult.Adapt<RecipeResponseJson>();

            for(int i = 0; i < recipeResult.Ingredients.Count; i++)
            {
                response.Ingredients.Add(recipeResult.Ingredients.ElementAt(i).Name);
            }


            return response;
        }

    }

}
