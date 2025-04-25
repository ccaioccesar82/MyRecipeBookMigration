using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.DataAccess.Repositories.User;

namespace MyRecipeBook.Infrastructure
{
    public static class InjectionDependencyInjection
    {
        

        public static void AddInfrastructure(this IServiceCollection service)
        {
            addDbContext(service);
            addRepositories(service);

        }

        public static void addDbContext(IServiceCollection service)
        {
            string connectionString = "Server=localhost;Database=meulivrodereceitas;Uid=root;Pwd=82707512";
            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

            service.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
            dbContextOptions.UseMySql(connectionString, serverVersion)

            );
        }


        public static void addRepositories(IServiceCollection service)
        {

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUnityOfWork, UnityOfWork>();
        }

    }
}
