namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger
{
    public interface ILoggedUser
    {
        public Task<Entities.UserEntities.User> FindUserByToken();
    }
}
