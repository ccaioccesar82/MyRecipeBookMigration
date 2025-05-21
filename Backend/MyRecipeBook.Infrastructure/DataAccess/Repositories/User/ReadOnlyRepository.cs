using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public ReadOnlyRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> ValidateOldPassword(Guid userId, string currentPassword) =>  await _dbContext.User.AnyAsync(u => u.Id == userId && u.Password == currentPassword);



        public async Task<bool> SearchUserWithExistedEmail(string email) => await _dbContext.User.AsNoTracking().AnyAsync(u => u.Email == email && u.Active == true);

        


        public async Task<Domain.Entities.UserEntities.User?> SeachUserByEmailAndPassword(string email, string password)
        {
            var result = await _dbContext.User.AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (result is null) return null;

            return result;
        }


        public async Task<Domain.Entities.UserEntities.User?> SearchUserById(Guid id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(u => u.Id == id);
        }


    }

}

