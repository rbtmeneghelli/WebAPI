using Microsoft.Data.SqlClient;
using WebAPI.Domain;

namespace WebAPI.InfraStructure.Data.Repositories;

public abstract class GenericDapperRepository
{
    protected EnvironmentVariables _environmentVariables;

    public GenericDapperRepository(EnvironmentVariables environmentVariables)
    {
        _environmentVariables = environmentVariables;
    }

    public virtual SqlConnection GetDbConnection() => new SqlConnection(_environmentVariables.ConnectionStringSettings.DefaultConnection);

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
