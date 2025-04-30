using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;


namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IUserCreateUserCase
    {
        public Task<AccessTokenResponseJson> Execute(UserCreationRequest request);
    }
}
