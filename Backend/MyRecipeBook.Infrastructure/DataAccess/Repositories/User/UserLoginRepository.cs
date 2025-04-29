using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class UserLoginRepository: IUserLoginRepository
    {

        private readonly MyRecipeBookDbContext _dbContext;

        public UserLoginRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users?> SeachUserByEmailAndPassword(string email, string password)
        {
            var result = await _dbContext.User.AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (result is null) return null;

            return result;
        }
    }
}
