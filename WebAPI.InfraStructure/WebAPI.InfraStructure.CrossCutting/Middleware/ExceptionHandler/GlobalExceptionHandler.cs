using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NPOI.Util;
using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.ExceptionHandler;

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
        var genericNotifyLogsService = httpContext.RequestServices.GetService<IGenericNotifyLogsService>();
        IProblemDetailsConfigFactory iproblemDetailsConfigFactory = _iProblemDetailsFactory.GetProblemDetailsByException(exception);
        var problemDetailsException = iproblemDetailsConfigFactory.GetProblemDetails(exception);

        httpContext.Response.StatusCode = problemDetailsException.Status.Value;

        _logger.LogError(exception, "Exception occurred: {Message} ", problemDetailsException.Detail);

        genericNotifyLogsService.GeneralLogService.SaveLogOnSeriLog(
            problemDetailsException.Logger,
            problemDetailsException.Class,
            problemDetailsException.Method,
            problemDetailsException.Detail,
            $"{problemDetailsException.File} - {problemDetailsException.Line}"
        );

        var problemDetails = problemDetailsException.Copy<ProblemDetails>();
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

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
        var genericNotifyLogsService = context.Features.Get<IGenericNotifyLogsService>();

        _logger.LogError(exception.Error, "Exception occurred: {Message} ", exception.Error.Message);
        IProblemDetailsConfigFactory iproblemDetailsConfigFactory = _iProblemDetailsFactory.GetProblemDetailsByException(exception.Error);
        var problemDetailsException = iproblemDetailsConfigFactory.GetProblemDetails(exception.Error);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problemDetailsException.Status.Value;

        _logger.LogError(exception.Error, "Exception occurred: {Message} ", problemDetailsException.Detail);

        genericNotifyLogsService.GeneralLogService.SaveLogOnSeriLog(
            problemDetailsException.Logger,
            problemDetailsException.Class,
            problemDetailsException.Method,
            problemDetailsException.Detail,
            $"{problemDetailsException.File} - {problemDetailsException.Line}"
        );

        var problemDetails = problemDetailsException.Copy<ProblemDetails>();
        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}