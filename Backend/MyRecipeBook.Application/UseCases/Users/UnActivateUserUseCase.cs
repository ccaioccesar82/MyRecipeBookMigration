using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using System.Security.Claims;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UnactivateUserUseCase : IUnactivateUserUseCase
    {

        private IUserUnactivateRepository _userUnactivateRepository;
        private IUnityOfWork _unityOfWork;

        public UnactivateUserUseCase(IUserUnactivateRepository userRepository, IUnityOfWork unityOfWork)
        {
            _userUnactivateRepository = userRepository;
            _unityOfWork = unityOfWork;
        }


        public async Task Execute(Guid id)
        {
            var result = await _userUnactivateRepository.SearchUserById(id);

            if (result == null)
            {
                throw new Exception("User não existe no banco de dados");
            }
            else
            {
                _userUnactivateRepository.UnctivateUser(result);
                await _unityOfWork.Commit();
            }

        }      
        
    }
}
