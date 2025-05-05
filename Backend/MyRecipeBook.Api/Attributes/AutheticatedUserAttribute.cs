using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;

namespace MyRecipeBook.Api.Attributes
{
    public class AutheticatedUserAttribute : TypeFilterAttribute
    {
        public AutheticatedUserAttribute() : base(typeof(AutheticatedUserFilter))
        {
        }
    }
}
