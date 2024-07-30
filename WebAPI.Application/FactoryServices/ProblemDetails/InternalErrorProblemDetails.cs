using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.FactoryInterfaces;

public sealed class InternalErrorProblemDetails : IProblemDetailsConfigFactory
{
    public InternalErrorProblemDetails()
    {
    }

    public ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}