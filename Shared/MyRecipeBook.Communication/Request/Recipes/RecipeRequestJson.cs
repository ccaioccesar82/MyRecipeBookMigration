using MyRecipeBook.Communication.Enums;
namespace MyRecipeBook.Communication.Request.Recipes
{
    public class RecipeRequestJson
    {
        public string Title { get; set; } = string.Empty;
        public CookingTime? Time { get; set; }
        public CookingTime? Difficulty { get; set; }

        public IList<InstructionCreateRequestJson> Instructions { get; set; } = new List<InstructionCreateRequestJson>();
        public IList<string> Ingredients { get; set; } = new List<string>();
        public IList<DishType> DishType { get; set; } = new List<DishType>();
    }
}
