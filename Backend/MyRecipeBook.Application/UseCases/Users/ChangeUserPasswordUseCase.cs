using MyRecipeBook.Application.Encrypter;
using MyRecipeBook.Application.FluentValidation.User;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class ChangeUserPasswordUseCase : IChangeUserPasswordUseCase
    {

        private readonly ILoggedUser _loggeduser;
        private IChageUserPasswordRepository _repository;
        private readonly IUnityOfWork _unityOfWork;

        public ChangeUserPasswordUseCase(ILoggedUser loggeduser, 
            IChageUserPasswordRepository repository, IUnityOfWork unityOfWork)
        {
            _loggeduser = loggeduser;
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(ChangeUserPasswordRequestJson request)
        {
            var userResult =  await _loggeduser.FindUserByToken();

            var oldPassword = EncrypterPassword.hashPassword(request.OldPassword);

            await Validate(userResult.Id, oldPassword, request);

            var newPassword = EncrypterPassword.hashPassword(request.NewPassword);

            await _repository.UpdateUser(userResult.Id, oldPassword, newPassword);

            await _unityOfWork.Commit();
        }


        private async Task Validate(Guid userId, string oldPassword ,ChangeUserPasswordRequestJson request)
        {
            ChangeUserPasswordValidator validator = new ChangeUserPasswordValidator();
            bool resultOldPassword = await _repository.ValidateOldPassword(userId, oldPassword);

            if(resultOldPassword == false)
            {
                throw new Exception("Senha Inválida");
            }

            ValidationResult resultNewPassword = validator.Validate(request);

            if(resultNewPassword.IsValid == false)
            {
                throw new Exception("Nova senha precisa ter entre 6 ou mais caracteres");

            }

        }

    }
}
