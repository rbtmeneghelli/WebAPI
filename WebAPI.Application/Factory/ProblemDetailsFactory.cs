using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Models.Factory.ProblemDetails;

namespace WebAPI.Application.Factory;

public sealed class ProblemDetailsFactory : IProblemDetailsFactory
{
    public IProblemDetailsConfigFactory GetProblemDetailsByException(Exception exception)
    {
        return exception switch
        {
            ArgumentNullException => new BadRequestProblemDetails(),
            ApplicationException => new InternalErrorProblemDetails(),
            UnauthorizedAccessException => new TokenProblemDetails(),
            _ => throw new Exception()
        };
    }
}