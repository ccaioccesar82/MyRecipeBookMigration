using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Exception.ExceptionBase
{
    public class ErrorOnLoginException : MyRecipeBookBaseException
    {
        public string ErrorMessage { get; set; } = string.Empty;


        public ErrorOnLoginException(string errorException)
        {
            ErrorMessage = errorException;

        }
    }
}
