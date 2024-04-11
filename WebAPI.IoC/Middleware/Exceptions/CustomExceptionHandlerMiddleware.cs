using WebAPI.Domain;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Configuration.Middleware.Exceptions;

/// <summary>
/// Exemplo de exceptionHandler valido antes do NET 8
/// Na Application do Startup.cs aplicar os itens abaixo:
/// app.UseMiddleware<CustomExceptionHandlerMiddleware>();
/// </summary>
public sealed class CustomExceptionHandlerMiddleware
{
    private ResponseError responseError = new ResponseError { Success = false };

    public CustomExceptionHandlerMiddleware()
    {

    }

    public Task InvokeAsync(HttpContext context)
    {
        return HandleAsync(context);
    }

    private Task HandleAsync(HttpContext context)
    {
        try
        {
            var expection = context.Features.Get<IExceptionHandlerFeature>();

            if (expection.Error is UnauthorizedAccessException)
            {
                responseError.ExceptionError = expection.Error.GetType().ToString();
                responseError.Errors = Constants.MESSAGE_ERROR_UNAUTH_EX;
                responseError.StatusCode = Constants.UNAUTHORIZED_ERROR_CODE;

            }

            else if (expection.Error is ArgumentNullException)
            {
                responseError.ExceptionError = expection.Error.GetType().ToString();
                responseError.Errors = Constants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = Constants.INTERNAL_ERROR_CODE;
            }

            else if (expection.Error is InvalidOperationException)
            {
                responseError.ExceptionError = expection.Error.GetType().ToString();
                responseError.Errors = Constants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = Constants.INTERNAL_ERROR_CODE;
            }

            else if (expection.Error is ApplicationException || expection.Error is Exception)
            {
                responseError.ExceptionError = expection.Error.GetType().ToString();
                responseError.Errors = Constants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = Constants.INTERNAL_ERROR_CODE;
            }

            else
            {
                responseError.ExceptionError = expection.Error.GetType().ToString();
                responseError.Errors = Constants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = Constants.INTERNAL_ERROR_CODE;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = responseError.StatusCode;
            context.Response.WriteAsync(responseError.SerializeObject());

            return Task.CompletedTask;
        }
        finally
        {

        }
    }
}


