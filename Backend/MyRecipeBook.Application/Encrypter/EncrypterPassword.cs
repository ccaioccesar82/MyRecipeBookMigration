using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.Encrypter
{
    public class EncrypterPassword
    {


        public static string hashPassword(string password)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA512.HashData(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash;

        }
    }
}
