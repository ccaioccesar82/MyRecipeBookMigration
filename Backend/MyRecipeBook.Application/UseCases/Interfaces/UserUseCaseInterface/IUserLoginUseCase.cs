using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Communication.Request.Users;

namespace MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface
{
    public interface IUserLoginUseCase
    {
        public Task Execute(UserRequestLogin request);
    }
}
