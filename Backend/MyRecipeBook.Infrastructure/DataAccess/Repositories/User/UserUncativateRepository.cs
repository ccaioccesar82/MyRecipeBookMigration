using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class UserUncativateRepository : IUserUnactivateRepository
    {

        private readonly MyRecipeBookDbContext _dbContext;

        public UserUncativateRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task UnctivateUser(Guid id)
        {
            var userResult = await _dbContext.User.SingleAsync(u => u.Id == id);

            userResult.SetActivate(false);
        }

        public async Task<Users?> SearchUserById(Guid id)
        {
            return await _dbContext.User.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
