namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users
{
    public interface IReadOnlyRepository
    {
        public Task<bool> ValidateOldPassword(Guid userId, string currentPassword);

        public Task<Entities.UserEntities.User?> SearchUserById(Guid id);

        public Task<bool> SearchUserWithExistedEmail(string email);

        public Task<Domain.Entities.UserEntities.User?> SeachUserByEmailAndPassword(string email, string password);
    }
}
