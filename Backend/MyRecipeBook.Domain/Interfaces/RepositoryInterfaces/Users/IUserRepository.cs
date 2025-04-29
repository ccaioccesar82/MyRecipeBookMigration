namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

public interface IUserRepository
{
    public Task CreateUser(Entities.User.Users user);
    public Task<bool> SearchUserWithExistedEmail(string email);
}

