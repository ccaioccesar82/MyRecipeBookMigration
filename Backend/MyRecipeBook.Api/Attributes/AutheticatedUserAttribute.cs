using Microsoft.AspNetCore.Mvc;

namespace MyRecipeBook.Api.Attributes
{
    public class AutheticatedUserAttribute : TypeFilterAttribute
    {
        public AutheticatedUserAttribute() : base(typeof(AutheticatedUserFilter))
        {
        }
    }
}
