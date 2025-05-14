using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using MyRecipeBook.Domain.Interfaces.SecurityInterface;
using MyRecipeBook.Domain.Interfaces.SecurityInterface.TokenValidator;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.DataAccess.Repositories.User;
using MyRecipeBook.Infrastructure.Security.Token;

namespace Microsoft.AspNetCore.Builder
{
    public static class InjectionDependencyInjection
    {
        

        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            addDbContext(service, configuration);
            addRepositories(service);
            AddTokens(service, configuration);
            AddLogger(service);
        }

        private static void addDbContext(IServiceCollection service, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Connection");

            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

            service.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
            dbContextOptions.UseMySql(connectionString, serverVersion)

            );
        }


        private static void addRepositories(IServiceCollection service)
        {

            service.AddScoped<IUserRepository, UserCreateRepository>();
            service.AddScoped<IUserUnactivateRepository, UserUncativateRepository>();
            service.AddScoped<IUserLoginRepository, UserLoginRepository>();
            service.AddScoped<IValidateUserInAttribute, ValidateUserInAttribute>();
            service.AddScoped<ILoggedUser, LoggedUser>();
            service.AddScoped<IUnityOfWork, UnityOfWork>();
            service.AddScoped<IChageUserPasswordRepository,  ChageUserPasswordRepository>();
        }

        private static void AddTokens(IServiceCollection service, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            service.AddScoped<ITokenGenerator>(options => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
            service.AddScoped<ITokenValidator>(options => new JwtTokenValidator(signingKey!));
        }

        private static void AddLogger(IServiceCollection service)
        {
            service.AddScoped<ILoggedUser, LoggedUser>();
        }

    }
}
