namespace MyRecipeBook.Communication.Response.Recipes
{
    public class RecipeShortResponseJson
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int IngredientNumber { get; set; }
    }
}
