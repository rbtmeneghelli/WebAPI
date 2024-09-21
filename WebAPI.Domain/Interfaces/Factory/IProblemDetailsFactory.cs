namespace WebAPI.Domain.Interfaces.Factory;

public interface IProblemDetailsFactory
{
    IProblemDetailsConfigFactory GetProblemDetailsByException(Exception exception);
}


