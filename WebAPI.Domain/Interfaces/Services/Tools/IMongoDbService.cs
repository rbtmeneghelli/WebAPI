namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IMongoDbService<TEntity> : IDisposable where TEntity : class
{
    Task CreateItem(TEntity entity);
    Task UpdateItem(string propertyNameToFind, object valueToFind, string propertyNameToChange, object valueToChange);
    Task<bool> ResearchItem(string propertyNameToFind, object valueToFind);
    Task DeleteItem(string propertyNameToFind, object valueToFind);
}
