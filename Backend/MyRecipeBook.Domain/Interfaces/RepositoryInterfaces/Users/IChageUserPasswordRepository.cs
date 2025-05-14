namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users
{
    public interface IChageUserPasswordRepository
    {
        public Task<bool> ValidateOldPassword(Guid userId, string currentPassword);
        public Task UpdateUser(Guid userId, string currentPassword, string NewPassword);
    }
}
