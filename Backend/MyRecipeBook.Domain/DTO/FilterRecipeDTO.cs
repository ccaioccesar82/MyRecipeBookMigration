using MyRecipeBook.Domain.Entities.Enums;

namespace MyRecipeBook.Domain.DTO
{
    public record FilterRecipeDTO
    {

        public string? RecipeTitle_Ingredient { get; set; } = string.Empty;
        public IList<CookingTime> CookingTime { get; set; } = [];
        public IList<Difficulty> Diffyculty { get; set; } = [];
        public IList<DishType> DishTypes { get; set; } = [];
    }
}
