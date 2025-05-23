using MyRecipeBook.Application.FluentValidation.Users;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Interfaces.Encrypter;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MyRecipeBook.Application.UseCases.Users
{
    public class ChangeUserPasswordUseCase : IChangeUserPasswordUseCase
    {

        private readonly ILoggedUser _loggeduser;
        private readonly IReadOnlyRepository _repository;
        private readonly IWriteOnlyRepository _writeOnly;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IEncrypterData _encrypter;

        public ChangeUserPasswordUseCase(ILoggedUser loggeduser, 
            IReadOnlyRepository repository, IUnityOfWork unityOfWork, 
            IEncrypterData encrypter,
            IWriteOnlyRepository writeOnly)
        {
            _loggeduser = loggeduser;
            _repository = repository;
            _unityOfWork = unityOfWork;
            _encrypter = encrypter;
            _writeOnly = writeOnly;
        }

        public async Task Execute(ChangeUserPasswordRequestJson request)
        {
            var userResult =  await _loggeduser.FindUserByToken();

            var oldPassword = _encrypter.hashData(request.OldPassword);

            await Validate(userResult.Id, oldPassword, request);

            var newPassword = _encrypter.hashData(request.NewPassword);

            await _writeOnly.ChangePassword(userResult.Id, oldPassword, newPassword);

            await _unityOfWork.Commit();
        }


        private async Task Validate(Guid userId, string oldPassword ,ChangeUserPasswordRequestJson request)
        {
            ChangeUserPasswordValidator validator = new ChangeUserPasswordValidator();

            ValidationResult resultNewPassword = validator.Validate(request);

            bool resultOldPassword = await _repository.ValidateOldPassword(userId, oldPassword);

            if (resultOldPassword == false)
            {
                throw new ErrorOnValidationException(ResourceMessageException.USER_OLDPASSWORD_INVALID);
            }


            if (!resultNewPassword.IsValid)
            {
                var errorMessage = resultNewPassword.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);

            }

        }

    }
}
