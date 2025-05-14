using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;

namespace MyRecipeBook.Api.Attributes
{
    public class AutheticatedUserFilter : IAsyncAuthorizationFilter
    {

        private readonly ITokenValidator _tokenValidator;
        private readonly IValidateUserInAttribute _validateUser;

        public AutheticatedUserFilter(ITokenValidator tokenValidator, IValidateUserInAttribute validateUser)
        {
            _tokenValidator = tokenValidator;
            _validateUser = validateUser;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string token = TokenOnRequest(context);
            Guid userId = _tokenValidator.ValidateTokenAndTakeUserIdInToken(token);

            var result = await _validateUser.VerifyIfUserExistAndIsActive(userId);

            if (result == false)
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

