using FluentValidation;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Application.FluentValidation.Recipes
{
    public class RecipeCreationValidator : AbstractValidator<RecipeRequestJson>
    {


        public RecipeCreationValidator()
        {

            RuleFor(recipe => recipe.Title).NotEmpty();
            RuleFor(recipe => recipe.Ingredients.Count).GreaterThan(0);
            RuleFor(recipe => recipe.Instructions.Count).GreaterThan(0);
            RuleFor(recipe => recipe.Difficulty).IsInEnum();
            RuleFor(recipe => recipe.Time).IsInEnum();
            RuleForEach(recipe => recipe.DishType).IsInEnum();
            RuleForEach(recipe => recipe.Ingredients).NotEmpty();

            RuleForEach(recipe => recipe.Instructions).ChildRules(instruction =>
                {
                    instruction.RuleFor(i => i.Step).GreaterThan(0);
                    instruction.RuleFor(i => i.ToDo).NotEmpty();             
                });

            RuleFor(recipe => recipe.Instructions)
            .Must(i => i.Select(x => x.Step).Distinct().Count() == i.Count);
        }
    }
}
