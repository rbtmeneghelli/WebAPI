using Dapper;
using System.Data;
using WebAPI.Application.Generic;
using WebAPI.Domain;

namespace WebAPI.InfraStructure.Data.Repositories;

public class WriteRepositoryDapper : GenericRepositoryDapper, IWriteRepositoryDapper
{
    public WriteRepositoryDapper(EnvironmentVariables environmentVariables) : base(environmentVariables) { }

    public async Task ExecuteQuery(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.ExecuteAsync(sql: sqlQuery);
        }
    }

    public async Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.ExecuteAsync(sql: sqlQuery, param: parameters);
        }
    }
}
