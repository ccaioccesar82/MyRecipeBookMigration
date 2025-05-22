using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.DTO;
using MyRecipeBook.Domain.Entities.RecipeEntities;
using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces.Recipes;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories.RecipeRepository
{
    public class ReciReadOnlyRepository: IReciReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public ReciReadOnlyRepository(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IList<Recipe>>FilterRecipes(Guid userId, FilterRecipeDTO filter)
        {
            var query = _dbContext.Recipes.
                AsNoTracking().Include(recipe => recipe.Ingredients)
                .Where(recipe => recipe.Active == true && recipe.UsersID == userId);


            var result = await query.ToListAsync();

            if (filter.DishTypes.Any())
            {
                query = query.Where(recipe => recipe.DishType.Any(dishtype => filter.DishTypes.Contains(dishtype.Type)));
            }

            if (filter.Diffyculty.Any())
            {

                query = query.Where(recipe => recipe.Difficulty.HasValue && filter.Diffyculty.Contains(recipe.Difficulty.Value));
            }

            if (filter.CookingTime.Any())
            {

                query = query.Where(recipe => recipe.Time.HasValue && filter.CookingTime.Contains(recipe.Time.Value));
            }

            if(!string.IsNullOrWhiteSpace(filter.RecipeTitle_Ingredient))
            {
                query = query.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(filter.RecipeTitle_Ingredient))
                || recipe.Title.Contains(filter.RecipeTitle_Ingredient));
            }


            return result;
        }
    }
}
