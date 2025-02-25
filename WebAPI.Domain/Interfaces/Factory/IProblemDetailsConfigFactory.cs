using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Factory;

public interface IProblemDetailsConfigFactory
{
    ProblemDetailsException GetProblemDetails(Exception exception);
}
