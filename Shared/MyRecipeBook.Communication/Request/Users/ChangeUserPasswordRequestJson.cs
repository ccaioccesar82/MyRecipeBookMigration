namespace MyRecipeBook.Communication.Request.Users
{
    public class ChangeUserPasswordRequestJson
    {

        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
