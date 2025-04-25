namespace MyRecipeBook.Communication.Request.Users
{
    public class UserCreationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
