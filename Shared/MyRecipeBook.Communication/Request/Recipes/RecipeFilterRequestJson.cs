using MyRecipeBook.Communication.Enums;

namespace MyRecipeBook.Communication.Request.Recipes
{
    public class RecipeFilterRequestJson
    {
        public string? RecipeTitle_Ingredient { get; set; } = string.Empty;
        public IList<CookingTime> CookingTime { get; set; } = [];
        public IList<Difficulty> Diffyculty { get; set; } = [];
        public IList<DishType> DishTypes { get; set; } = [];
    }
}
