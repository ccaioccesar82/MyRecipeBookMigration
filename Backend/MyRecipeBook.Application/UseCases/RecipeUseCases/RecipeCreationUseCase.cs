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
            //Valida os campos da receita



            //Faz o mapeamento da entidade receita 
            Recipe recipe = request.Adapt<Recipe>();


            /* Pega a lista de instruções e valida a ordem dos steps. Se o user passar os steps todos bagunçados,
            o sistema irá ordenar do menor número para o maior e depois atribuir os steps por ordem de 1,2,3...
            */

            var instructions = request.Instructions.OrderBy(i => i.Step).ToList();

            for (var i = 0; i < instructions.Count; i++)
            {

                instructions.ElementAt(i).Step = i + 1;

            }

            recipe.Instructions = instructions.Adapt<IList<Instruction>>();

            return recipe;
        }

    }
}
