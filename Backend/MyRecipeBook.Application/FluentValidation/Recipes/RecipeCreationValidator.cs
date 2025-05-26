using FluentValidation;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.FluentValidation.Recipes
{
    public class RecipeCreationValidator : AbstractValidator<RecipeCreationAndUpdateRequestJson>
    {
        public RecipeCreationValidator()
        {

            RuleFor(recipe => recipe.Title).NotEmpty().WithMessage(ResourceMessageException.RECIPE_TITLE_EMPTY);
            RuleFor(recipe => recipe.Ingredients.Count).GreaterThan(0).WithMessage(ResourceMessageException.RECIPE_INGREDIENT_EMPTY);
            RuleFor(recipe => recipe.Instructions.Count).GreaterThan(0).WithMessage(ResourceMessageException.RECIPE_INSTRUCTION_EMPTY);
            RuleFor(recipe => recipe.Difficulty).IsInEnum().WithMessage(ResourceMessageException.RECIPE_DIFFICULTY_ISENUM);
            RuleFor(recipe => recipe.Time).IsInEnum().WithMessage(ResourceMessageException.RECIPE_COOKINGTIME_ISENUM);
            RuleForEach(recipe => recipe.DishType).IsInEnum().WithMessage(ResourceMessageException.RECIPE_DISHTYPE_ISENUM);
            RuleForEach(recipe => recipe.Ingredients).NotEmpty().WithMessage(ResourceMessageException.RECIPE_INGREDIENT_WITH_ONE_EMPTY);

            RuleForEach(recipe => recipe.Instructions).ChildRules(instruction =>
                {
                    instruction.RuleFor(i => i.Step).GreaterThan(0).WithMessage(ResourceMessageException.RECIPE_INSTRUCTION_STEP_0);
                    instruction.RuleFor(i => i.ToDo).NotEmpty().WithMessage(ResourceMessageException.RECIPE_INSTRUCTION_TODO_EMPTY);
                });

            RuleFor(recipe => recipe.Instructions)
            .Must(i => i.Select(x => x.Step).Distinct().Count() == i.Count).WithMessage(ResourceMessageException.RECIPE_INSTRUCTION_STEP_REPEATED);
        }
    }
}
