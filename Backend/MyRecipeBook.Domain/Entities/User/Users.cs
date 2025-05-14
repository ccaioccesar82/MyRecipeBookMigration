using System.ComponentModel.DataAnnotations.Schema;

namespace MyRecipeBook.Domain.Entities.User
{
    public class Users : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        


        public void SetPassword(string password)
        {
            Password = password;

        }


        public void SetActivate(bool activate)
        {
           Active = activate;

        }
    }

}
