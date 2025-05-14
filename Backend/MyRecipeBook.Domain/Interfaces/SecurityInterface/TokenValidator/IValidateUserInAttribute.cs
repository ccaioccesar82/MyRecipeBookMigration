namespace MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator
{
    public interface IValidateUserInAttribute
    {
        public Task<bool> VerifyIfUserExistAndIsActive(Guid userIdetifier);
    }
}
