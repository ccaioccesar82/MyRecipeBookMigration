using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;
using MyRecipeBook.Communication.Response.Users;
using MyRecipeBook.Communication.Response.Token;
using MyRecipeBook.Domain.Interfaces.Encrypter;
using MyRecipeBook.Exception.ExceptionBase;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IReadOnlyRepository _readOnly;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IEncrypterData _encrypter;

        public UserLoginUseCase(IWriteOnlyRepository writeonly,
            IReadOnlyRepository readOnly , ITokenGenerator tokenGenerator, 
            IEncrypterData encrypter)
        {
            _tokenGenerator = tokenGenerator;
            _encrypter = encrypter;
            _readOnly = readOnly;

        }


        public async Task<AccessTokenResponseJson> Execute(UserRequestLogin request)
        {
            var hashedPassword = _encrypter.hashData(request.Password);

            var userResult = await _readOnly.SeachUserByEmailAndPassword(request.Email, hashedPassword);

            if (userResult == null)
            {
                throw new ErrorOnLoginException(ResourceMessageException.USER_LOGIN_INVALID);
            }

            return new AccessTokenResponseJson
            {
                AccessToken = _tokenGenerator.Generate(userResult.Id)
            }; 

        }






    }
}
