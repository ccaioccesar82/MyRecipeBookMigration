using MyRecipeBook.Communication.Enums;
namespace MyRecipeBook.Communication.Request.Recipes
{
    public class RecipeCreationRequestJson
    {
        public string Title { get; set; } = string.Empty;
        public IList<string> Ingredients { get; set; } = new List<string>();

        public IList<InstructionCreateRequestJson> Instructions { get; set; } = new List<InstructionCreateRequestJson>();

        public IList<DishType> DishType { get; set; } = new List<DishType>();
        public CookingTime? Time { get; set; }
        public CookingTime? Difficulty { get; set; }


    }
}
