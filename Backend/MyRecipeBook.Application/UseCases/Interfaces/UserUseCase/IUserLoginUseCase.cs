using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;

namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IUserLoginUseCase
    {
        public Task<AccessTokenResponseJson> Execute(UserRequestLogin request);
    }
}
