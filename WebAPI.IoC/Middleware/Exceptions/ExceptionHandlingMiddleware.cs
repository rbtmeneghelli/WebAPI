using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebAPI.Infra.Structure.IoC.Middleware.Exceptions;

/// <summary>
/// Exemplo de exceptionHandler valido antes do NET 8
/// Na Application do Startup.cs aplicar os itens abaixo:
/// app.UseMiddleware<ExceptionHandlingMiddleware>();
/// </summary>
public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private ResponseError responseError = new ResponseError { Success = false };

    public ExceptionHandlingMiddleware(RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ResponseError
        {
            Success = false
        };
        switch (exception)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Token Inválido"))
                {
                    response.StatusCode = StatusCodes.Status403Forbidden;
                    errorResponse.Errors = ex.Message;
                    break;
                }
                response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Errors = ex.Message;
                break;
            case KeyNotFoundException ex:
                response.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.Errors = ex.Message;
                break;
            default:
                response.StatusCode = StatusCodes.Status500InternalServerError;
                errorResponse.Errors = "Internal Server error. Verifique os Logs!";
                break;
        }
        _logger.LogError(exception.Message);
        await context.Response.WriteAsync(errorResponse.SerializeObject());
    }
}