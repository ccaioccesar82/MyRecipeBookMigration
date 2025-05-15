namespace MyRecipeBook.Communication.Request.Recipes
{
    public class InstructionCreateRequestJson
    {
        public int Step { get; set; }
        public string ToDo { get; set; } = string.Empty;

    }
}
