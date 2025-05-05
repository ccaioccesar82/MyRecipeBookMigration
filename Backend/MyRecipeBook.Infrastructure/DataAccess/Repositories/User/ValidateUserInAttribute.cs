using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;
using MyRecipeBook.Infrastructure.DataAccess;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class ValidateUserInAttribute: IValidateUserInAttribute    {

        private readonly MyRecipeBookDbContext _dbContext;

        public ValidateUserInAttribute(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Validate(Guid userIdetifier)
        {
            return await _dbContext.User.AnyAsync(u => u.Id == userIdetifier && u.Active == true);
        }
    }
}
