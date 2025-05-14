using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;
using MyRecipeBook.Communication.Response.Users;


namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IUserCreateUserCase
    {
        public Task<UserCreationResponseJson> Execute(UserCreationRequest request);
    }
}
