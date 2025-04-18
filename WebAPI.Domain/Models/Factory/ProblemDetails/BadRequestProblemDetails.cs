using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public class BadRequestProblemDetails : IProblemDetailsConfigFactory
{
    public BadRequestProblemDetails()
    {
    }

    public ProblemDetailsException GetProblemDetails(Exception exception)
    {
        StackTrace stackTrace = new StackTrace(exception, true);

        //for (int i = 0; i < stackTrace.FrameCount; i++)
        //{
        //    StackFrame frame = stackTrace.GetFrame(i);
        //    Console.WriteLine("Arquivo: " + frame.GetFileName());
        //    Console.WriteLine("Método: " + frame.GetMethod().Name);
        //    Console.WriteLine("Classe: " + frame.GetMethod().DeclaringType);
        //    Console.WriteLine("Linha: " + frame.GetFileLineNumber());
        //    Console.WriteLine();
        //}

        StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);

        ProblemDetailsException problemDetailsException = new()
        {
            Logger = EnumLogger.LogError,
            Status = StatusCodes.Status400BadRequest,
            Title = "BadRequest",
            File = frame.GetFileName(),
            Class = frame.GetMethod().Name,
            Method = frame.GetMethod().DeclaringType.Name,
            Line = frame.GetFileLineNumber(),
            Detail = exception.Message
        };

        return problemDetailsException;
    }
}