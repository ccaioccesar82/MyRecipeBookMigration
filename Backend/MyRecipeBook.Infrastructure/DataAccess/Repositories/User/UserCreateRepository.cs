using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class UserCreateRepository : IUserRepository
    {

        private readonly MyRecipeBookDbContext _dbContext;

        public UserCreateRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateUser(Users user)
        {
           await _dbContext.User.AddAsync(user);
        }


        public async Task<bool> SearchUserWithExistedEmail(string email)
        {
           
            return await _dbContext.User.AsNoTracking().AnyAsync(u => u.Email == email && u.Active == true);

        }

    }
}
