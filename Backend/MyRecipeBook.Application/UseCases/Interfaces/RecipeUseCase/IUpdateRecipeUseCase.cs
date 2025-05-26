using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase
{
    public interface IUpdateRecipeUseCase
    {
        public Task Execute(Guid recipeId, RecipeCreationAndUpdateRequestJson request);
    }
}
