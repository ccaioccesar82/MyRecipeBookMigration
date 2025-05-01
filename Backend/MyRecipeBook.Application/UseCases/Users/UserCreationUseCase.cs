using MyRecipeBook.Application.FluentValidation.User;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Users;
using MyRecipeBook.Application.AutoMapperService;
using MyRecipeBook.Domain.Entities.User;
using MyRecipeBook.Application.Encrypter;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using AutoMapper;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Communication.Response.Token;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;


namespace MyRecipeBook.Application.UseCases.Users
{
    public class UserCreationUseCase : IUserCreateUserCase
    {

        private IUserRepository _iuserRepository;
        private IMapper _mapper;
        private IUnityOfWork _unityOfWork;
        private ITokenGenerator _tokenGenerator;


        public UserCreationUseCase(IUserRepository iuserRepository, IMapper mapper, IUnityOfWork unityOfWork, ITokenGenerator tokenGenerator)
        {
            _iuserRepository = iuserRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserCreationResponseJson> Execute(UserCreationRequest request)
        {
            //Valida o usuário
            await ValidateEmail(request.Email);
            Validate(request);


            //Faz um mapeamento com o AutoMapper

            var user = _mapper.Map<Domain.Entities.User.Users>(request);

            //Faz um hash na senha

            var hashPassword = EncrypterPassword.hashPassword(request.Password);
            user.SetPassword(hashPassword);

            //salva no banco de dados

            await _iuserRepository.CreateUser(user);

            await _unityOfWork.Commit();

            return new UserCreationResponseJson
            {
                UserIdentifier = user.UserIdentifier.ToString(),
                accessTokenResponseJson = new AccessTokenResponseJson
                {
                    AccessToken = _tokenGenerator.Generate(user.UserIdentifier)
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

                throw new Exception("Erro de validação");
            }

        }

        private async Task ValidateEmail(string email) // Verifica se já existe um usuário com o mesmo email
        {
            var result = await _iuserRepository.SearchUserWithExistedEmail(email);

            if (result == true)
            {

                throw new Exception("Usuário já salvo no banco de dados");
            }

        }
    }
}
