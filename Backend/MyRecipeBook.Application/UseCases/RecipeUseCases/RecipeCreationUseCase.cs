using Mapster;
using MapsterMapper;
using MyRecipeBook.Application.UseCases.Interfaces.Recipe;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Domain.Entities.RecipeEntities;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class RecipeCreationUseCase : IRecipeCreationUseCase
    {

        private readonly IMapper _mapper;


        public RecipeCreationUseCase(IMapper mapper)
        {

            _mapper = mapper;
        }


        public Recipe Execute(RecipeRequestJson request)
        {

            //Faz o mapeamento das entidades
            Recipe recipe = request.Adapt<Recipe>();


            //pega a lista de instruções e valida a ordem dos steps
            var instructions = request.Instructions;

            return recipe;
        }

    }
}
