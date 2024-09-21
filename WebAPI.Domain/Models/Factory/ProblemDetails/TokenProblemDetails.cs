using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.ProblemDetails;

public sealed class TokenProblemDetails : IProblemDetailsConfigFactory
{
    public TokenProblemDetails()
    {
    }

    public Microsoft.AspNetCore.Mvc.ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status419AuthenticationTimeout,
            Title = "Token Expired",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}