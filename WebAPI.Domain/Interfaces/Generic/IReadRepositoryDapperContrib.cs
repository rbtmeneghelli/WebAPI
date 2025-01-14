namespace WebAPI.Domain.Interfaces.Generic;

public interface IReadRepositoryDapperContrib<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<IEnumerable<TEntity>> GetByAll();
}
