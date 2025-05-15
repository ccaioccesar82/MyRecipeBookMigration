using MyRecipeBook.Domain.Entities.Enums;
using MyRecipeBook.Domain.Entities.User;

namespace MyRecipeBook.Domain.Entities.RecipeEntities
{
    public class Recipe : EntityBase
    {
        public string Title { get; set; } = string.Empty;

        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();
        public IList<DishType> DishType { get; set; } = new List<DishType>();
        public Enums.CookingTime? Time { get; set; }
        public Enums.Difficulty? Difficulty { get; set; }

        public Guid UsersID { get; set; }
        public required Users User { get; set; }


    }
}
