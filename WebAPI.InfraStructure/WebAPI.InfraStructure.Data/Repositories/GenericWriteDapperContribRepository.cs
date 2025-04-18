using Dapper.Contrib.Extensions;
using FastPackForShare.Bases.Generics;
using System.Data;
using WebAPI.Domain;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories;

public class GenericWriteDapperContribRepository<TEntity> : GenericDapperRepository, IGenericWriteDapperContribRepository<TEntity> where TEntity : GenericEntityModel
{
    public GenericWriteDapperContribRepository(EnvironmentVariables environmentVariables) : base(environmentVariables) { }

    public async Task<int> Insert(TEntity entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var id = await idbConnection.InsertAsync(entity);
            return id;
        }
    }

    public async Task InsertMultiple(IEnumerable<TEntity> entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.InsertAsync(entity);            
        }
    }

    public async Task Update(TEntity entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.UpdateAsync(entity);
        }
    }

    public async Task UpdateMultiple(IEnumerable<TEntity> entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.UpdateAsync(entity);
        }
    }

    public async Task Delete(TEntity entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.DeleteAsync(entity);
        }
    }

    public async Task DeleteMultiple(IEnumerable<TEntity> entity)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            await idbConnection.DeleteAsync(entity);
        }
    }
}


