namespace MyRecipeBook.Domain.Interfaces.SecurityInterface
{
    public interface ITokenGenerator
    {
        public string Generate(Guid userInditifier);
    }
}
