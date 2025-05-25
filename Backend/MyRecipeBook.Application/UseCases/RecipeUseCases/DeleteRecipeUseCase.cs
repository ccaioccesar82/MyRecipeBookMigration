using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class DeleteRecipeUseCase : IDeleteRecipeUseCase
    {

        private readonly IRecipeReadOnlyRepository _readOnly;
        private readonly IRecipeWriteOnlyRepository _writeOnly;
        private readonly ILoggedUser _loggedUser;
        private readonly IUnityOfWork _unityOfWork;

        public DeleteRecipeUseCase(IRecipeReadOnlyRepository readOnly,
            IRecipeWriteOnlyRepository writeOnly,
            ILoggedUser loggedUser,
            IUnityOfWork unityOfWork)
        {

            _readOnly = readOnly;
            _writeOnly = writeOnly;
            _loggedUser = loggedUser;
            _unityOfWork = unityOfWork;

        }



        public async Task Execute(Guid recipeId)
        {
            var user = await _loggedUser.FindUserByToken();

            var recipeResult = await _readOnly.FindRecipeById(recipeId, user.Id);

            if (recipeResult == null)
            {
                throw new NotFoundException(ResourceMessageException.NOT_FOUND_ERROR);
            }

            _writeOnly.DeleteRecipe(recipeResult);

            await _unityOfWork.Commit();
        }
    }
}
