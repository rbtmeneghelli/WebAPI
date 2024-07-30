using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Application.FactoryInterfaces;

public interface IProblemDetailsConfigFactory
{
    ProblemDetails GetProblemDetails(string exceptionMessage);
}
