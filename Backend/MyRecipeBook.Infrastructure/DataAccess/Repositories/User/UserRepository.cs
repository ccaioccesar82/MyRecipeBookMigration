using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class UserRepository : IUserRepository
    {

        private readonly MyRecipeBookDbContext _dbContext;

        public UserRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateUser(Domain.Entities.User.Users user)
        {
           await _dbContext.User.AddAsync(user);
        }


        public async Task<bool> SearchUserWithExistedEmail(string email)
        {
           
            return await _dbContext.User.AnyAsync(u => u.Email == email && u.Active == true);

        }

        public async Task UnctivateUser(long id)
        {
            var userResult = await _dbContext.User.SingleAsync(u=> u.Id == id);

            userResult.SetActivate(false);
        }

        public async Task<Users?> SearchUserById(long id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
