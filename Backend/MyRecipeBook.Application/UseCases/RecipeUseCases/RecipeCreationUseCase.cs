using Mapster;
using MapsterMapper;
using MyRecipeBook.Application.FluentValidation.Recipes;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class RecipeCreationUseCase : IRecipeCreationUseCase
    {

        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;
        private readonly IRecipeWriteOnlyRepository _writeOnly;
        private readonly IUnityOfWork _unityOfWork;

        public RecipeCreationUseCase(IMapper mapper, 
            ILoggedUser loggedUser,
            IRecipeWriteOnlyRepository writeOnly,
            IUnityOfWork unityOfWork)

        {
            _mapper = mapper;
            _loggedUser = loggedUser;
            _writeOnly = writeOnly;
            _unityOfWork = unityOfWork;
        }


        public async Task<RecipeCreationResponseJson> Execute(RecipeCreationRequestJson request)
        {
            var user = await _loggedUser.FindUserByToken();
            //Valida os campos da receita
            Validate(request);

            //Faz o mapeamento da entidade receita
            Recipe recipe = request.Adapt<Recipe>();
            //Atribui o userId logado à essa receita
            recipe.UsersID = user.Id;

            for (int i = 0; i < request.Ingredients.Count; i++) {

                recipe.Ingredients.Add(new Ingredient
                {
                    Name = request.Ingredients.ElementAt(i)

                });
            }

            /* Pega a lista de instruções e valida a ordem dos steps. Se o user passar os steps bagunçados,
            o sistema irá ordenar do menor número para o maior e depois atribuir os steps por ordem de 1,2,3...
            */

            var instructions = request.Instructions.OrderBy(i => i.Step).ToList();

            for (var i = 0; i < instructions.Count; i++)
            {

                instructions.ElementAt(i).Step = i + 1;

            }

            recipe.Instructions = instructions.Adapt<IList<Instruction>>();

            await _writeOnly.CreateRecipe(recipe);

            await _unityOfWork.Commit();

            return new RecipeCreationResponseJson
            {
                Title = recipe.Title
            };

        }

        private void Validate(RecipeCreationRequestJson request)
        {
            var validator = new RecipeCreationValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception("Erro na validação");

            }
        }

    }
}
