﻿using MyRecipeBook.Domain.Interfaces.TokenProvider;
namespace MyRecipeBook.Infrastructure.Security.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string Value()
        {
            string authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            if (string.IsNullOrWhiteSpace(authorization))
            {
                throw new Exception("Sem autorização");
            }
;
            return authorization.Substring(7).Trim();
        }
    }
}
