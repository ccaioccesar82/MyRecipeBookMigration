namespace MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator
{
    public interface ITokenValidator
    {
        public Guid ValidateTokenAndTakeUserIdInToken(string token);
    }
}
