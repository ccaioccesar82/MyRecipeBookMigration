using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.UserEntities;
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

        public void UnctivateUser(Domain.Entities.UserEntities.User userResult)
        {
            userResult.SetActivate(false);
        }

        public async Task<Domain.Entities.UserEntities.User?> SearchUserById(Guid id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(u => u.Id == id);
        }


    }
}
