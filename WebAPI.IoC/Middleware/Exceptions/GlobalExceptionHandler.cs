using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Infra.Structure.IoC.Middleware.Exceptions;

/// <summary>
/// Exemplo de exceptionHandler valido a partir do NET 8
/// Na Service do Startup.cs aplicar os itens abaixo:
/// builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
/// builder.Services.AddProblemDetails();
/// Na Application do Startup.cs aplicar os itens abaixo:
/// app.UseExceptionHandler(); 
/// LINK REFERÊNCIA >> https://macoratti.net/23/12/aspc_globalexchandling1.htm
/// </summary>
public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails problemDetails = new();

        if (exception is BadHttpRequestException)
        {
            _logger.LogError(exception, "Exception occurred: {Message} ", exception.Message);
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = "BadRequest";
            problemDetails.Detail = exception.Message;
        }
        else
        {
            _logger.LogError(exception, "Exception occurred: {Message} ", exception.Message);
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            problemDetails.Title = "Server Error";
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
