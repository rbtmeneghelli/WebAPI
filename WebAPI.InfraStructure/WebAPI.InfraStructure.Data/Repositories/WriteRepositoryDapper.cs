using Dapper;
using System.Data;
using WebAPI.Application.Generic;

namespace WebAPI.InfraStructure.Data.Repositories;

public class WriteRepositoryDapper<TEntity> : GenericRepositoryDapper, IWriteRepositoryDapper
{
    public WriteRepositoryDapper(IDbConnection idbConnection) : base(idbConnection) { }

    public async Task ExecuteQuery(string sqlQuery)
    {
        await _idbConnection.ExecuteAsync(sql: sqlQuery);
    }

    public async Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters)
    {
        await _idbConnection.ExecuteAsync(sql: sqlQuery, param: parameters);
    }
}
