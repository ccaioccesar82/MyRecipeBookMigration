using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using System.Security.Claims;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class UnactivateUserUseCase : IUnactivateUserUseCase
    {

        private readonly IWriteOnlyRepository _writeonly;
        private readonly IReadOnlyRepository _readOnly;
        private IUnityOfWork _unityOfWork;

        public UnactivateUserUseCase(IWriteOnlyRepository writeonly, IReadOnlyRepository readOnly , IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            _writeonly = writeonly;
            _readOnly = readOnly;
        }


        public async Task Execute(Guid id)
        {
            var result = await _readOnly.SearchUserById(id);

            if (result == null)
            {
                throw new Exception("User não existe no banco de dados");
            }
            else
            {
                _writeonly.UnctivateUser(result);
                await _unityOfWork.Commit();
            }

        }      
        
    }
}
