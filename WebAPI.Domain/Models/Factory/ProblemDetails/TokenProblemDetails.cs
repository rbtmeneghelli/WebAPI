using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public sealed class TokenProblemDetails : IProblemDetailsConfigFactory
{
    public TokenProblemDetails()
    {
    }

    public ProblemDetailsException GetProblemDetails(Exception exception)
    {
        StackTrace stackTrace = new StackTrace(exception, true);

        StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);

        ProblemDetailsException problemDetailsException = new()
        {
            Logger = EnumLogger.LogError,
            Status = StatusCodes.Status419AuthenticationTimeout,
            Title = "Token Expired",
            File = frame.GetFileName(),
            Class = frame.GetMethod().Name,
            Method = frame.GetMethod().DeclaringType.Name,
            Line = frame.GetFileLineNumber(),
            Detail = exception.Message
        };

        return problemDetailsException;
    }
}