namespace MyRecipeBook.Exception.ExceptionBase
{
    public class ErrorOnValidationException : MyRecipeBookBaseException
    {

        public IList<string> ErrorMessages { get; set; } = new List<string>();

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public ErrorOnValidationException(string message)
        {
            ErrorMessages.Add(message);
        }

    }
}
