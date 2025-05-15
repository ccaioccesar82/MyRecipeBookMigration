using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities.RecipeEntities
{
    public class Instruction : EntityBase
    {
        public int Step { get; set; }
        public string ToDo { get; set; } = string.Empty;

        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }

    }
}
