using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

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
            await ValidateUserId(id);
            await _userUnactivateRepository.UnctivateUser(id);

            await _unityOfWork.Commit();
        }      
        private async Task ValidateUserId(Guid id)
        {
           var result = await _userUnactivateRepository.SearchUserById(id);

            if (result == null)
            {
                throw new Exception("User não existe no banco de dados");
            }
        }
    }
}
