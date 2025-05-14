using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;

namespace MyRecipeBook.Infrastructure.Security.Token
{
    public class JwtTokenValidator : TokenEncoding, ITokenValidator
    {

        private readonly string _jwtToken;

        public JwtTokenValidator(string jwtToken)
        {
            _jwtToken = jwtToken;
        }


        public Guid ValidateTokenAndTakeUserIdInToken(string token)
        {
            var validatorParameter = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = SecurityKey(_jwtToken),
                ClockSkew = new TimeSpan(0)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, validatorParameter, out _);

            var userIdentifier = principal.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

            return Guid.Parse(userIdentifier);
        }
    }
}
