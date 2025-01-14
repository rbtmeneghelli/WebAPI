namespace WebAPI.Domain.Interfaces.Generic;

public interface IWriteRepositoryDapperContrib<TEntity> : IDisposable where TEntity : class
{
    Task<int> Insert(TEntity entity);
    Task InsertMultiple(IEnumerable<TEntity> entity);
    Task Update(TEntity entity);
    Task UpdateMultiple(IEnumerable<TEntity> entity);
    Task Delete(TEntity entity);
    Task DeleteMultiple(IEnumerable<TEntity> entity);
}