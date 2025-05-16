namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

public interface IUserRepository
{
    public Task CreateUser(Entities.UserEntities.User user);
    public Task<bool> SearchUserWithExistedEmail(string email);
}

