using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UnactivateUserUseCase : IUnactivateUserUseCase
    {

        private IUserRepository _userRepository;
        private IUnityOfWork _unityOfWork;

        public UnactivateUserUseCase(IUserRepository userRepository, IUnityOfWork unityOfWork)
        {
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
        }


        public async Task Execute(long id)
        {
            await ValidateUserId(id);
            await _userRepository.UnctivateUser(id);

            await _unityOfWork.Commit();
        }      
        private async Task ValidateUserId(long id)
        {
           var result = await _userRepository.SearchUserById(id);

            if (result == null)
            {
                throw new Exception("User não existe no banco de dados");
            }
        }
    }
}
