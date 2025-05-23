namespace MyRecipeBook.Exception.ExceptionBase
{
    public class ErrorOnTokenValidation : MyRecipeBookBaseException
    {
        public string ErrorMessage { get; set; } = string.Empty;


        public ErrorOnTokenValidation(string errorException)
        {
            ErrorMessage = errorException;

        }
    }
}
