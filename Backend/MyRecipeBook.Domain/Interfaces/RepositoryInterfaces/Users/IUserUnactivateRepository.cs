using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users
{
    public interface IUserUnactivateRepository
    {
        public Task<Entities.User.Users?> SearchUserById(Guid id);
        public void UnctivateUser(Entities.User.Users userResult);

    }
}
