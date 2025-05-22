using Mapster;
using MapsterMapper;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Domain.DTO;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class FilterRecipesUseCase : IFilterRecipesUseCase
    {

        private readonly IReciReadOnlyRepository _readOnly;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public FilterRecipesUseCase(IReciReadOnlyRepository readOnly, 
            ILoggedUser loggedUser,
            IMapper mapper)
        {
            _readOnly = readOnly;
            _loggedUser = loggedUser;
            _mapper = mapper;
        }


        public async Task<IList<RecipeFilteredResponseJson>> Execute(RecipeFilterRequestJson request)
        {
            //pega o userid
            var user = await _loggedUser.FindUserByToken();

            var filter = request.Adapt<FilterRecipeDTO>();

            var result = await _readOnly.FilterRecipes(user.Id, filter);

            var listReponse = result.Adapt<IList<RecipeFilteredResponseJson>>();

            return listReponse;
        }

    }

}
