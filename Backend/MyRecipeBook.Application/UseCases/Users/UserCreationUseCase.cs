using Mapster;
using MapsterMapper;
using MyRecipeBook.Application.FluentValidation.Users;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;
using MyRecipeBook.Communication.Response.Users;
using MyRecipeBook.Domain.Entities.UserEntities;
using MyRecipeBook.Domain.Interfaces.Encrypter;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;


namespace MyRecipeBook.Application.UseCases.Users
{
    public class UserCreationUseCase : IUserCreateUserCase
    {

        private IUserWriteOnlyRepository _writeOnly;
        private readonly IUserReadOnlyRepository _readOnly;
        private IMapper _mapper;
        private IUnityOfWork _unityOfWork;
        private ITokenGenerator _tokenGenerator;
        private readonly IEncrypterData _encrypter;


        public UserCreationUseCase(IUserWriteOnlyRepository writeOnly, 
            IUserReadOnlyRepository readOnly, 
            IMapper mapper, 
            IUnityOfWork unityOfWork, 
            ITokenGenerator tokenGenerator, IEncrypterData encrypter)
        {
            _writeOnly = writeOnly;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _tokenGenerator = tokenGenerator;
            _encrypter = encrypter;
            _readOnly = readOnly;
        }

        public async Task<UserCreationResponseJson> Execute(UserCreationRequest request)
        {
            //Valida o usuário
            Validate(request);
            await ValidateEmail(request.Email);

            //Faz um mapeamento com o AutoMapper

            var user = request.Adapt<User>();

            //Faz um hash na senha

            var hashPassword = _encrypter.hashData(request.Password);
            user.SetPassword(hashPassword);

            //salva no banco de dados

            await _writeOnly.CreateUser(user);

            await _unityOfWork.Commit();

            return new UserCreationResponseJson
            {
                accessTokenResponseJson = new AccessTokenResponseJson
                {
                    AccessToken = _tokenGenerator.Generate(user.Id)
                }

            };
        }

        private void Validate(UserCreationRequest request) // Valida os campos Nome, Email e Senha
        {

            UserCreationValidator validator = new UserCreationValidator();

            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var erroMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessage);
            }

        }

        private async Task ValidateEmail(string email) // Verifica se já existe um usuário com o mesmo email
        {
            var result = await _readOnly.SearchUserWithExistedEmail(email);

            if (result == true)
            {
                throw new ErrorOnValidationException(ResourceMessageException.USER_EMAIL_ALREADY_EXIST);
            }

        }
    }
}
