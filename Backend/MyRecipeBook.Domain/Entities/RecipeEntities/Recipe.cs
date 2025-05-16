using MyRecipeBook.Domain.Entities.UserEntities;

namespace MyRecipeBook.Domain.Entities.RecipeEntities
{
    public class Recipe : EntityBase
    {
        public string Title { get; set; } = string.Empty;

        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();
        public IList<Enums.DishType> DishType { get; set; } = new List<Enums.DishType>();
        public Enums.CookingTime? Time { get; set; }
        public Enums.Difficulty? Difficulty { get; set; }

        public Guid UsersID { get; set; }
        public User? User { get; set; }


    }
}
