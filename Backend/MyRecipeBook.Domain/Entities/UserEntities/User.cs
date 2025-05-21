using System.ComponentModel.DataAnnotations.Schema;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Entities.RecipeEntities;

namespace MyRecipeBook.Domain.Entities.UserEntities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public IList<Recipe> Recipes = new List<Recipe>();


        public void SetPassword(string password)
        {
            Password = password;
        }

    }

}
