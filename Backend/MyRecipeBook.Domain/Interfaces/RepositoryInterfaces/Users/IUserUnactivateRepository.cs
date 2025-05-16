using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users
{
    public interface IUserUnactivateRepository
    {
        public Task<Entities.UserEntities.User?> SearchUserById(Guid id);
        public void UnctivateUser(Entities.UserEntities.User userResult);

    }
}
