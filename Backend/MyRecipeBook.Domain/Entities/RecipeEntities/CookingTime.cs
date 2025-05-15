using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities.RecipeEntities
{
    public class CookingTime: EntityBase
    {
        public Enums.CookingTime Time {  get; set; }
        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
