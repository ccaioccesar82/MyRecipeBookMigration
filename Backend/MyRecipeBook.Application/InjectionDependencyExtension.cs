using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Application.UseCases.RecipeUseCases;
using MyRecipeBook.Application.UseCases.Users;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Domain.DTO;
using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Entities.UserEntities;


namespace Microsoft.AspNetCore.Builder
{
    public static class InjectionDepencyExtension
    {

        public static void AddApplication(this IServiceCollection service)
        {
            addUseCases(service);
            RegisterMaps(service);
        }


        private static void addUseCases(IServiceCollection service)
        {
            service.AddScoped<IUserCreateUserCase, UserCreationUseCase>();
            service.AddScoped<IUnactivateUserUseCase, UnactivateUserUseCase>();
            service.AddScoped<IChangeUserPasswordUseCase, ChangeUserPasswordUseCase>();
            service.AddScoped<IUserLoginUseCase, UserLoginUseCase>();
            service.AddScoped<IRecipeCreationUseCase, RecipeCreationUseCase>();
            service.AddScoped<IFilterRecipesUseCase, FilterRecipesUseCase>();
        }



        private static void RegisterMaps(IServiceCollection service)
        {

            service.AddMapster();

            TypeAdapterConfig<UserCreationRequest, User>
                .NewConfig()
                .Ignore(dest => dest.Password);


            TypeAdapterConfig<RecipeCreationRequestJson, Recipe>
            .NewConfig()
            .Map(dest => dest.DishType, source => source.DishType.Distinct())
            .Ignore(dest => dest.Ingredients)
            .Ignore(dest => dest.UsersID);

            TypeAdapterConfig<InstructionCreateRequestJson, Instruction>
              .NewConfig();

            TypeAdapterConfig<Recipe, RecipeFilteredResponseJson>
             .NewConfig()
             .Map(dest => dest.Title, source => source.Title)
             .Map(dest => dest.IngredientNumber, source => source.Ingredients.Count());


            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
