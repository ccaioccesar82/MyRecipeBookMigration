using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Domain.DTO;
using MyRecipeBook.Domain.Entities.RecipeEntities;

namespace MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes
{
    public interface IReciReadOnlyRepository
    {
        public Task<IList<Recipe>> FilterRecipes(Guid userId, FilterRecipeDTO filter);
    }
}
