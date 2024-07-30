using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.FactoryInterfaces;

public sealed class TokenProblemDetails : IProblemDetailsConfigFactory
{
    public TokenProblemDetails()
    {
    }

    public ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status419AuthenticationTimeout,
            Title = "Token Expired",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}