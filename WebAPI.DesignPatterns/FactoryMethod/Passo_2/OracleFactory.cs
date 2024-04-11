using WebAPI.DesignPatterns.FactoryMethod.Passo_2;

namespace WebAPI.DesignPatterns.FactoryMethod.Passo_1;

// Concrete Creator
public class OracleFactory : DbFactory
{
    // Factory Method
    public override DbConnector CreateConnector(string connectionString)
    {
        return new OracleDbConnector(connectionString);
    }
}