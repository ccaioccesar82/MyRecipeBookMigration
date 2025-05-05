using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace MyRecipeBook.Infrastructure.Security.Token
{
    public class TokenEncoding
    {


        public SymmetricSecurityKey SecurityKey(string signingKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(signingKey);

            return new SymmetricSecurityKey(bytes);

        }
    }
}
