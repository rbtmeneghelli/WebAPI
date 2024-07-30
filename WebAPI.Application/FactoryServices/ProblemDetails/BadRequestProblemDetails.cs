using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Application.FactoryInterfaces;

namespace WebAPI.Application.FactoryServices.Exceptions;

public sealed class BadRequestProblemDetails : IProblemDetailsConfigFactory
{
    public BadRequestProblemDetails()
    {
    }

    public ProblemDetails GetProblemDetails(string exceptionMessage)
    {
        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "BadRequest",
            Detail = exceptionMessage
        };

        return problemDetails;
    }
}

