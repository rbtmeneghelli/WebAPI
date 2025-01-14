using Microsoft.Data.SqlClient;
using WebAPI.Domain;

namespace WebAPI.InfraStructure.Data.Repositories;

public abstract class GenericRepositoryDapper
{
    protected EnvironmentVariables _environmentVariables;

    public GenericRepositoryDapper(EnvironmentVariables environmentVariables)
    {
        _environmentVariables = environmentVariables;
    }

    public virtual SqlConnection GetDbConnection() => new SqlConnection(_environmentVariables.ConnectionStringSettings.DefaultConnection);

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
