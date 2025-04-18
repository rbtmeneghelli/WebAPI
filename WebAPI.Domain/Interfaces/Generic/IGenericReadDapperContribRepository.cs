namespace WebAPI.Domain.Interfaces.Generic;

public interface IGenericReadDapperContribRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<IEnumerable<TEntity>> GetByAll();
}
