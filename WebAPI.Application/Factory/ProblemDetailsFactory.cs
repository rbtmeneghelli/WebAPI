using WebAPI.Application.FactoryInterfaces;
using WebAPI.Application.FactoryServices.Exceptions;

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