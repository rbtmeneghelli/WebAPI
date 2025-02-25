using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public sealed class InternalErrorProblemDetails : IProblemDetailsConfigFactory
{
    public InternalErrorProblemDetails()
    {
    }

    public ProblemDetailsException GetProblemDetails(Exception exception)
    {
        StackTrace stackTrace = new StackTrace(exception, true);

        StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);

        ProblemDetailsException problemDetailsException = new()
        {
            Logger = EnumLogger.LogError,
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            File = frame.GetFileName(),
            Class = frame.GetMethod().Name,
            Method = frame.GetMethod().DeclaringType.Name,
            Line = frame.GetFileLineNumber(),
            Detail = exception.Message
        };

        return problemDetailsException;
    }
}