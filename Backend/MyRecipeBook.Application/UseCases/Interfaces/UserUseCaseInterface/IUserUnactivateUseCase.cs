namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IUnactivateUserUseCase
    {
        public Task Execute(long id);
    }
}
