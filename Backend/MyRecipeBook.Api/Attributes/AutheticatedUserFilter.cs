using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Api.Attributes
{
    public class AutheticatedUserFilter : IAsyncAuthorizationFilter
    {

        private readonly ITokenValidator _tokenValidator;
        private readonly IUserReadOnlyRepository _validateUser;

        public AutheticatedUserFilter(ITokenValidator tokenValidator, IUserReadOnlyRepository validateUser)
        {
            _tokenValidator = tokenValidator;
            _validateUser = validateUser;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                string token = TokenOnRequest(context);
                Guid userId = _tokenValidator.ValidateTokenAndTakeUserIdInToken(token);

                var result = await _validateUser.SearchUserById(userId);

                if (result == null)
                {
                    throw new ErrorOnTokenValidation(ResourceMessageException.UNAUTHORIZED_USER);

                }

            }
            catch (ErrorOnTokenValidation ex)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ex.ErrorMessage));

            }

            catch (SecurityTokenExpiredException)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenExpired"));
            }
            catch
            {

                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceMessageException.UNAUTHORIZED_USER));

            }
        }

        private string TokenOnRequest(AuthorizationFilterContext context)
        {

            var authentication = context.HttpContext.Request.Headers.Authorization.ToString();
            if (string.IsNullOrWhiteSpace(authentication))
            {
                throw new ErrorOnTokenValidation(ResourceMessageException.UNAUTHORIZED_USER);
            }

            return authentication.Substring(7).Trim();


        }

    }

}

