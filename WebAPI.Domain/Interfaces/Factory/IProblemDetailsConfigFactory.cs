using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Domain.Interfaces.Factory;

public interface IProblemDetailsConfigFactory
{
    ProblemDetails GetProblemDetails(string exceptionMessage);
}
