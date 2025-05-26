using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Users.Logger;
using MyRecipeBook.Exception.ExceptionBase;
using MyRecipeBook.Exception;
using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Communication.Request.Recipes;
using Mapster;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;
using MyRecipeBook.Application.FluentValidation.Recipes;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;

namespace MyRecipeBook.Application.UseCases.RecipeUseCases
{
    public class UpdateRecipeUseCase : IUpdateRecipeUseCase
    {
        private readonly IRecipeReadOnlyRepository _readOnly;
        private readonly IRecipeWriteOnlyRepository _writeOnly;
        private readonly ILoggedUser _loggedUser;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateRecipeUseCase(IRecipeReadOnlyRepository readOnly,
            IRecipeWriteOnlyRepository writeOnly,
             ILoggedUser loggedUser,
             IUnityOfWork unityOfWork)
        {

            _readOnly = readOnly;
            _writeOnly = writeOnly;
            _loggedUser = loggedUser;
            _unityOfWork = unityOfWork;
        }


        public async Task Execute(Guid recipeId, RecipeCreationAndUpdateRequestJson request)
        {
            Validate(request);

            var user = await _loggedUser.FindUserByToken();

            var recipe = await _readOnly.FindRecipeById(recipeId, user.Id);

            if (recipe == null)
            {
                throw new NotFoundException(ResourceMessageException.NOT_FOUND_ERROR);
            }

            recipe.Instructions.Clear();
            recipe.DishType.Clear();
            recipe.Ingredients.Clear();

            request.Adapt(recipe);

            for (int i = 0; i < request.Ingredients.Count; i++)
            {

                recipe.Ingredients.Add(new Ingredient
                {
                    Name = request.Ingredients.ElementAt(i)

                });
            }

            var instructions = request.Instructions.OrderBy(i => i.Step).ToList();

            for (var i = 0; i < instructions.Count; i++)
            {

                instructions.ElementAt(i).Step = i + 1;

            }

            recipe.Instructions = instructions.Adapt<IList<Instruction>>();

            _writeOnly.UpdateRecipe(recipe);

            await _unityOfWork.Commit();
        }








        private void Validate(RecipeCreationAndUpdateRequestJson request)
        {
            var validator = new RecipeCreationValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errormessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errormessages);
            }
        }
    }
}
