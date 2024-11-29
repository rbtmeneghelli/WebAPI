using System.Data;

namespace WebAPI.InfraStructure.Data.Repositories;

public abstract class GenericRepositoryDapper
{
    protected readonly IDbConnection _idbConnection;

    public GenericRepositoryDapper(IDbConnection idbConnection)
    {
        _idbConnection = idbConnection;
    }

    public void Dispose()
    {
        _idbConnection?.Dispose();
        GC.SuppressFinalize(this);
    }
}
