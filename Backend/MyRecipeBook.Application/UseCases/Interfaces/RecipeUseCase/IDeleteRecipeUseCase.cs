namespace MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase
{
    public interface IDeleteRecipeUseCase
    {
        public Task Execute(Guid recipeId);
    }
}
