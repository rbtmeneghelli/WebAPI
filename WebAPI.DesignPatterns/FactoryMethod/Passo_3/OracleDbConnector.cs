using WebAPI.DesignPatterns.FactoryMethod.Passo_3;

namespace WebAPI.DesignPatterns.FactoryMethod.Passo_2;

// Concrete Product
public class OracleDbConnector : DbConnector
{
    public OracleDbConnector(string connectionString) : base(connectionString)
    {
        ConnectionString = connectionString;
    }

    public override Connection Connect()
    {
        Console.WriteLine("Conectando ao banco Oracle...");
        var connection = new Connection(ConnectionString);
        connection.Open();

        return connection;
    }
}