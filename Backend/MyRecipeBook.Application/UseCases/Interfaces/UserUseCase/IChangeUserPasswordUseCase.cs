using MyRecipeBook.Communication.Request.Users;

namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IChangeUserPasswordUseCase
    {
        public Task Execute(ChangeUserPasswordRequestJson request);
    }
}
