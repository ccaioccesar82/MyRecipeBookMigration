using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Application.Encrypter;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private IUserLoginRepository _userLoginRepository;

        public UserLoginUseCase(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }


        public async Task Execute(UserRequestLogin request)
        {
            var hashedPassword = EncrypterPassword.hashPassword(request.Password);

            await Validate(request.Email, hashedPassword);


        }


        private async Task Validate(string email, string password)
        {
            var result = await _userLoginRepository.SeachUserByEmailAndPassword(email, password);

            if(result == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }

        }
    }
}
