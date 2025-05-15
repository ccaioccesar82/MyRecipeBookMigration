using System.Security.Cryptography;
using System.Text;
using MyRecipeBook.Domain.Interfaces.Encrypter;

namespace MyRecipeBook.Infrastructure.Security.Encrypter
{
    public class EncrypterData : IEncrypterData
    {


        public string hashData(string password)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA512.HashData(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;

        }

    }
}