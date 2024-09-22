using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.IoC.Middleware.ExceptionHandler;

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
    private readonly IProblemDetailsFactory _iProblemDetailsFactory;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsFactory iProblemDetailsFactory)
    {
        _logger = logger;
        _iProblemDetailsFactory = iProblemDetailsFactory;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message} ", exception.Message);
        IProblemDetailsConfigFactory iproblemDetailsConfigFactory = _iProblemDetailsFactory.GetProblemDetailsByException(exception);
        var problemDetails = iproblemDetailsConfigFactory.GetProblemDetails(exception.Message);

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

/// <summary>
/// Exemplo de exceptionHandler valido antes do NET 8
/// Na Application do Startup.cs aplicar os itens abaixo:
/// app.UseMiddleware<ExceptionHandlingMiddleware>();
/// </summary>
public sealed class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IProblemDetailsFactory _iProblemDetailsFactory;

    public ExceptionHandlingMiddleware(
        ILogger<ExceptionHandlingMiddleware> logger, IProblemDetailsFactory iProblemDetailsFactory)
    {
        _logger = logger;
        _iProblemDetailsFactory = iProblemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await HandleAsync(context);
    }

    private async Task HandleAsync(HttpContext context)
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>();

        _logger.LogError(exception.Error, "Exception occurred: {Message} ", exception.Error.Message);
        IProblemDetailsConfigFactory iproblemDetailsConfigFactory = _iProblemDetailsFactory.GetProblemDetailsByException(exception.Error);
        var problemDetails = iproblemDetailsConfigFactory.GetProblemDetails(exception.Error.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problemDetails.Status.Value;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}