namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

public interface IUserWriteOnlyRepository
{
    public Task CreateUser(Entities.UserEntities.User user);
    public void UnctivateUser(Domain.Entities.UserEntities.User userResult);

    public Task ChangePassword(Guid userId, string currentPassword, string NewPassword);


}

