using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities.Recipe
{
     public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } =  string.Empty;
        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
