using Dapper;
using WebAPI.Domain.Models;
using System.Data;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain;

namespace WebAPI.InfraStructure.Data.Repositories;

public class ReadRepositoryDapper<TEntity> : GenericRepositoryDapper, IReadRepositoryDapper<TEntity> where TEntity : class
{
    public ReadRepositoryDapper(EnvironmentVariables environmentVariables) : base(environmentVariables) { }

    public async Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var list = await idbConnection.QueryAsync<TEntity>(sql: sqlQuery);
            return list;
        }
    }

    public async Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            TEntity entity = await idbConnection.QueryFirstOrDefaultAsync<TEntity>(sql: sqlQuery);
            return entity;
        }
    }

    public async Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var reader = await idbConnection.QueryMultipleAsync(sql: sqlQuery);
            return new QueryResult<TEntity>
            {
                Count = reader.Read<int>().FirstOrDefault(),
                Result = reader.Read<TEntity>()
            };
        }
    }
}
