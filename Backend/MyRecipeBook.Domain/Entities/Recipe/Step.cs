using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities.Recipe
{
    public class Step
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string ToDo { get; set; } = string.Empty;

        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }

    }
}
