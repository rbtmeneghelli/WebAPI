using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public sealed class InternalErrorProblemDetails : IProblemDetailsConfigFactory
{
    public InternalErrorProblemDetails()
    {
    }

    public Microsoft.AspNetCore.Mvc.ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}