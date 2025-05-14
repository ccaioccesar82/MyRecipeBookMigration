using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Communication.Response.Token;

namespace MyRecipeBook.Communication.Response.Users
{
    public class UserLoginResponseJson
    {
        public string UserIdentifier { get; set; } = string.Empty;
        public AccessTokenResponseJson accessTokenResponseJson { get; set; } = default!;
    }
}
