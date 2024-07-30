namespace WebAPI.Application.FactoryInterfaces;

public interface IProblemDetailsFactory
{
    IProblemDetailsConfigFactory GetProblemDetailsByException(Exception exception);
}


