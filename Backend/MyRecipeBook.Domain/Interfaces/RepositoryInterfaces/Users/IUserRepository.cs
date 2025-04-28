namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

public interface IUserRepository
{
    public Task CreateUser(Entities.User.Users user);
    public Task<bool> SearchUserWithExistedEmail(string email);
    public Task<Entities.User.Users?> SearchUserById(Guid id);
    public Task UnctivateUser(Guid id);
}

