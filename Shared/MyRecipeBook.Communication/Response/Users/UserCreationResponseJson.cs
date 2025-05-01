using MyRecipeBook.Communication.Response.Token;

namespace MyRecipeBook.Communication.Response.Users
{
    public class UserCreationResponseJson
    {
        public string UserIdentifier { get; set; } = string.Empty;
        public AccessTokenResponseJson accessTokenResponseJson { get; set; } = default!;
    }
}
