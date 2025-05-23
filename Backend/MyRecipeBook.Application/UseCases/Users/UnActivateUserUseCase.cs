using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using System.Security.Claims;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UnactivateUserUseCase : IUnactivateUserUseCase
    {

        private readonly IWriteOnlyRepository _writeonly;
        private readonly ILoggedUser _loggedUser;
        private IUnityOfWork _unityOfWork;

        public UnactivateUserUseCase(IWriteOnlyRepository writeonly, ILoggedUser loggedUser, IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            _writeonly = writeonly;
            _loggedUser = loggedUser;
        }


        public async Task Execute()
        {
            var result = await _loggedUser.FindUserByToken();

            _writeonly.UnctivateUser(result);
             await _unityOfWork.Commit();
        

        }      
        
    }
}
