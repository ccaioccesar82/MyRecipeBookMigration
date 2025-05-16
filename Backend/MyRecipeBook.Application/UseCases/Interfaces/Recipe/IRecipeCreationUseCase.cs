using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Application.UseCases.Interfaces.Recipe
{
    public interface IRecipeCreationUseCase
    {
        public Domain.Entities.RecipeEntities.Recipe Execute(RecipeRequestJson request);
    }
}
