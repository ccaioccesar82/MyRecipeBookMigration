using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.AutoMapperService;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Application.UseCases.Users;


namespace Microsoft.AspNetCore.Builder
{
    public static class InjectionDepencyExtension
    {

        public static void AddApplication(this IServiceCollection service)
        {
            addUseCases(service);
            addAutoMapper(service);

        }


        private static void addAutoMapper (IServiceCollection service)
        {
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {

                options.AddProfile(new AutoMapperValidator());
            }).CreateMapper();

            service.AddScoped(option =>  autoMapper);

        }


        private static void addUseCases(IServiceCollection service)
        {
            service.AddScoped<IUserCreateUserCase, UserCreationUseCase>();
            service.AddScoped<IUnactivateUserUseCase, UnactivateUserUseCase>();
            service.AddScoped<IUserLoginUseCase, UserLoginUseCase>();
        }

    }
}
