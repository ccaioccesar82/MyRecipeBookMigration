using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class WriteOnlyRepository : IWriteOnlyRepository
    {

        private readonly MyRecipeBookDbContext _dbContext;

        public WriteOnlyRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateUser(Domain.Entities.UserEntities.User user)
        {
            await _dbContext.User.AddAsync(user);
        }


        public void UnctivateUser(Domain.Entities.UserEntities.User userResult)
        {
            userResult.SetActivate(false);
        }


        public async Task ChangePassword(Guid userId, string currentPassword, string NewPassword)
        {

            var result = await _dbContext.User.SingleAsync(u => u.Id == userId && u.Password == currentPassword);

            result.SetPassword(NewPassword);
        }

    }
}
