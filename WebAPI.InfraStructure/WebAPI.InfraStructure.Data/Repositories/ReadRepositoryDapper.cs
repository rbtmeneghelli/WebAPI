using Dapper;
using WebAPI.Domain.Models;
using System.Data;
using WebAPI.Domain.Interfaces.Generic;


namespace WebAPI.InfraStructure.Data.Repositories
{
    public class ReadRepositoryDapper<TEntity> : GenericRepositoryDapper, IReadRepositoryDapper<TEntity> where TEntity : class
    {
        protected readonly IDbConnection _idbConnection;

        public ReadRepositoryDapper(IDbConnection idbConnection) : base(idbConnection) { }

        public async Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery)
        {
            var list = await _idbConnection.QueryAsync<TEntity>(sql: sqlQuery);
            return list;
        }

        public async Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery)
        {
            TEntity entity = await _idbConnection.QueryFirstOrDefaultAsync<TEntity>(sql: sqlQuery);
            return entity;
        }

        public async Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery)
        {
            var reader = await _idbConnection.QueryMultipleAsync(sql: sqlQuery);
            return new QueryResult<TEntity>
            {
                Count = reader.Read<int>().FirstOrDefault(),
                Result = reader.Read<TEntity>()
            };
        }
    }
}
