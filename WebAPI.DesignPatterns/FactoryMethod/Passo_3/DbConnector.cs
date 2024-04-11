using WebAPI.DesignPatterns.FactoryMethod.Passo_3;

namespace WebAPI.DesignPatterns.FactoryMethod.Passo_2;

// Abstract Product
public abstract class DbConnector
{
    protected DbConnector(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected string ConnectionString { get; set; }
    public abstract Connection Connect();
}