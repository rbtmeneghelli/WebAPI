using Dapper;
using System.Data;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain;
using FastPackForShare.Models;
using FastPackForShare.Bases.Generics;

namespace WebAPI.InfraStructure.Data.Repositories;

public class GenericReadDapperRepository<TEntity> : GenericDapperRepository, IGenericReadDapperRepository<TEntity> where TEntity : GenericEntityModel
{
    public GenericReadDapperRepository(EnvironmentVariables environmentVariables) : base(environmentVariables) { }

    public async Task<IEnumerable<TEntity>> GetAll(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var list = await idbConnection.QueryAsync<TEntity>(sql: sqlQuery);
            return list;
        }
    }

    public async Task<TEntity> GetFirstResult(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            TEntity entity = await idbConnection.QueryFirstOrDefaultAsync<TEntity>(sql: sqlQuery);
            return entity;
        }
    }

    public async Task<QueryResultModel<TEntity>> GetMultipleResult(string sqlQuery)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var reader = await idbConnection.QueryMultipleAsync(sql: sqlQuery);
            return new QueryResultModel<TEntity>
            {
                Count = reader.Read<int>().FirstOrDefault(),
                Result = reader.Read<TEntity>()
            };
        }
    }
}
