using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Api.ExceptionFilters
{
    public class ExceptionApplicationFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyRecipeBookBaseException)
            {
                HandleExceptionReciBook(context);

            }
            else
            {
                UnknownExceptionHandler(context);
            }

        }


        private void HandleExceptionReciBook(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));

            }

            if(context.Exception is ErrorOnLoginException)
            {
                var exception = context.Exception as ErrorOnLoginException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new ObjectResult(new ResponseErrorJson(exception!.ErrorMessage));
            }

        }


        private void UnknownExceptionHandler(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.INTERNAL_SERVER_ERROR));

            }

        }

    }
}
