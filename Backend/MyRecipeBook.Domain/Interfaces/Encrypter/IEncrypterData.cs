namespace MyRecipeBook.Domain.Interfaces.Encrypter
{
    public interface IEncrypterData
    {
        public string hashData(string password);
    }
}
