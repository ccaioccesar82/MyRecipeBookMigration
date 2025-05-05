using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;

namespace MyRecipeBook.Infrastructure.Security.Token
{
    public class JwtTokenGenerator : TokenEncoding, ITokenGenerator
    {
        private readonly uint _expirationTimeMinute;
        private readonly string _signingKey;

        public JwtTokenGenerator(uint expirationTimeMinute, string signingKey)
        {
            _expirationTimeMinute = expirationTimeMinute;
            _signingKey = signingKey;

        }

        public string Generate(Guid userInditifier)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, userInditifier.ToString())
            };


            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinute),
                SigningCredentials = new SigningCredentials(SecurityKey(_signingKey), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
