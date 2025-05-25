using MyRecipeBook.Communication.Enums;

namespace MyRecipeBook.Communication.Response.Recipes
{
    public class RecipeResponseJson
    {
        public string Title { get; set; } = string.Empty;

        public IList<string> Ingredients { get; set; } = new List<string>();
        public IList<InstructionResponseJson> Instructions { get; set; } = [];
        public IList<DishType> DishType { get; set; } = new List<DishType>();
        public Enums.CookingTime? Time { get; set; }
        public Enums.Difficulty? Difficulty { get; set; }
    }
}
