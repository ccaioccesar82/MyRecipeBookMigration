using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class ChageUserPasswordRepository : IChageUserPasswordRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public ChageUserPasswordRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> ValidateOldPassword(Guid userId, string currentPassword) =>  await _dbContext.User.AnyAsync(u => u.Id == userId && u.Password == currentPassword);


        public async Task UpdateUser(Guid userId, string currentPassword, string NewPassword)
        {

            var result = await _dbContext.User.SingleAsync(u => u.Id == userId && u.Password == currentPassword);

            result.SetPassword(NewPassword);
        }
    }
}
