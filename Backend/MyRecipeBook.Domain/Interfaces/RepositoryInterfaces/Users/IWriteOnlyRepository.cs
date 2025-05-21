namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

public interface IWriteOnlyRepository
{
    public Task CreateUser(Entities.UserEntities.User user);
    public void UnctivateUser(Domain.Entities.UserEntities.User userResult);

    public Task ChangePassword(Guid userId, string currentPassword, string NewPassword);


}

