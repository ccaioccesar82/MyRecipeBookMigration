namespace MyRecipeBook.Exception.ExceptionBase
{
    public class NotFoundException : MyRecipeBookBaseException
    {

        public string ErroMessage { get; set; } = string.Empty;

        public NotFoundException(string erroMessage)
        {
            ErroMessage = erroMessage;
        }
    }
}
