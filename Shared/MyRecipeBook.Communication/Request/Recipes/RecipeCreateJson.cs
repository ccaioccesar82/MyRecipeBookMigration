using MyRecipeBook.Domain.Entities.RecipeEntities;

namespace MyRecipeBook.Communication.Request.Recipes
{
    public class RecipeCreateJson
    {
        public string Title { get; set; } = string.Empty;
        public Domain.Entities.Enums.CookingTime? Time { get; set; }
        public Domain.Entities.Enums.CookingTime? Difficulty { get; set; }

        public IList<InstructionCreateRequestJson> Instructions { get; set; } = new List<InstructionCreateRequestJson>();
        public IList<string> Ingredients { get; set; } = new List<string>();
        public IList<Domain.Entities.Enums.DishType> DishType { get; set; } = new List<Domain.Entities.Enums.DishType>();
    }
}
