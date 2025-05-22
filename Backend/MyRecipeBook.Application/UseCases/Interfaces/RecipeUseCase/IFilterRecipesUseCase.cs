using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase
{
    public interface IFilterRecipesUseCase
    {
        public Task<IList<RecipeFilteredResponseJson>> Execute(RecipeFilterRequestJson request);
    }
}
