using MyRecipeBook.Domain.Entities.Enums;

namespace MyRecipeBook.Domain.Entities.Recipe
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public IList<Step> Steps { get; set; } = new List<Step>();
        public DishType DishType { get; set; }
        public Time Time { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}
