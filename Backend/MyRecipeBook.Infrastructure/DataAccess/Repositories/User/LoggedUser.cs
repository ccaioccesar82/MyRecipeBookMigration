using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Domain.Interfaces.TokenProvider;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.User
{
    public class LoggedUser : ILoggedUser

    {
        private readonly MyRecipeBookDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(MyRecipeBookDbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }


        public async Task<Users> SearchUserByToken()
        {
            string token = _tokenProvider.Value();

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            string identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

            return await _dbContext.User.AsNoTracking().FirstAsync(u => u.Active == true && u.Id == Guid.Parse(identifier));
        }
    }
}
