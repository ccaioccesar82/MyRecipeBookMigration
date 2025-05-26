namespace MyRecipeBook.Communication.Response.Recipes
{
    public class RecipeListResponseJson
    {
        public IList<RecipeShortResponseJson> Recipes { get; set; } = [];
    }
}
