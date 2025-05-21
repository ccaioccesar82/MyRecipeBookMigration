using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;

namespace MyRecipeBook.Api.Attributes
{
    public class AutheticatedUserFilter : IAsyncAuthorizationFilter
    {

        private readonly ITokenValidator _tokenValidator;
        private readonly IReadOnlyRepository _validateUser;

        public AutheticatedUserFilter(ITokenValidator tokenValidator, IReadOnlyRepository validateUser)
        {
            _tokenValidator = tokenValidator;
            _validateUser = validateUser;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string token = TokenOnRequest(context);
            Guid userId = _tokenValidator.ValidateTokenAndTakeUserIdInToken(token);

            var result = await _validateUser.SearchUserById(userId);

            if (result == null)
            {
                throw new Exception("User não autorizado");

            }
        }

        private string TokenOnRequest(AuthorizationFilterContext context)
        {
            var authentication = context.HttpContext.Request.Headers.Authorization.ToString();
            if (string.IsNullOrWhiteSpace(authentication))
            {
                throw new Exception("Não Autorizado");
            }

            return authentication.Substring(7).Trim();

        }

    }

    }

