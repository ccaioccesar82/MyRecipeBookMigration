using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.DataAccess.Repositories.User;

namespace Microsoft.AspNetCore.Builder
{
    public static class InjectionDependencyInjection
    {
        

        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            addDbContext(service, configuration);
            addRepositories(service);

        }

        public static void addDbContext(IServiceCollection service, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Connection");

            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

            service.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
            dbContextOptions.UseMySql(connectionString, serverVersion)

            );
        }


        public static void addRepositories(IServiceCollection service)
        {

            service.AddScoped<IUserRepository, UserCreateRepository>();
            service.AddScoped<IUserUnactivateRepository, UserUncativateRepository>();
            service.AddScoped<IUserLoginRepository, UserLoginRepository>();
            service.AddScoped<IUnityOfWork, UnityOfWork>();
        }

    }
}
