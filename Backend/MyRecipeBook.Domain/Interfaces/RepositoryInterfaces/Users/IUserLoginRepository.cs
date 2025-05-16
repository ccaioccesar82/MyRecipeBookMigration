using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users
{
    public interface IUserLoginRepository
    {
        public Task<Entities.UserEntities.User?> SeachUserByEmailAndPassword(string email, string password);
    }
}
