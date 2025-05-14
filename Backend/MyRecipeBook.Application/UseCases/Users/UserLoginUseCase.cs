using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Application.Encrypter;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;
using MyRecipeBook.Communication.Response.Users;
using MyRecipeBook.Communication.Response.Token;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private IUserLoginRepository _userLoginRepository;
        private ITokenGenerator _tokenGenerator;

        public UserLoginUseCase(IUserLoginRepository userLoginRepository, ITokenGenerator tokenGenerator)
        {
            _userLoginRepository = userLoginRepository;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<UserLoginResponseJson> Execute(UserRequestLogin request)
        {
            var hashedPassword = EncrypterPassword.hashPassword(request.Password);

            var userResult = await _userLoginRepository.SeachUserByEmailAndPassword(request.Email, hashedPassword);

            if (userResult == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }

            return new UserLoginResponseJson
            {
                accessTokenResponseJson = new AccessTokenResponseJson
                {
                    AccessToken = _tokenGenerator.Generate(userResult.Id)
                }

            };

        }

    }
}
