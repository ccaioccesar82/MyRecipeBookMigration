using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator
{
    public interface IValidateUserInAttribute
    {
        public Task<bool> Validate(Guid userIdetifier);
    }
}
