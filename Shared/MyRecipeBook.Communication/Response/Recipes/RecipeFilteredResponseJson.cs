using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Communication.Response.Recipes
{
    public class RecipeFilteredResponseJson
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int IngredientNumber { get; set; }
    }
}
