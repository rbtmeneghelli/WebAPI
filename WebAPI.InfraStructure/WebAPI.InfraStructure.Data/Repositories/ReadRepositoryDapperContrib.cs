using Dapper.Contrib.Extensions;
using System.Data;
using WebAPI.Domain;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories;

public class ReadRepositoryDapperContrib<TEntity> : GenericRepositoryDapper, IReadRepositoryDapperContrib<TEntity> where TEntity : class
{
    public ReadRepositoryDapperContrib(EnvironmentVariables environmentVariables) : base(environmentVariables) { }

    public async Task<TEntity> GetById(int id)
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var data = await idbConnection.GetAsync<TEntity>(id);
            return data;
        }
    }

    public async Task<IEnumerable<TEntity>> GetByAll()
    {
        using (IDbConnection idbConnection = GetDbConnection())
        {
            var data = await idbConnection.GetAllAsync<TEntity>();
            return data;
        }
    }
}


