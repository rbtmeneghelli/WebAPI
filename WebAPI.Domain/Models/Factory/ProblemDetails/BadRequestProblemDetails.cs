using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public sealed class BadRequestProblemDetails : IProblemDetailsConfigFactory
{
    public BadRequestProblemDetails()
    {
    }

    public Microsoft.AspNetCore.Mvc.ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "BadRequest",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}

