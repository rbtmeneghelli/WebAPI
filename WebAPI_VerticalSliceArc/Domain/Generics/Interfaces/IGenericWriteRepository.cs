using WebAPI_VerticalSliceArc.Domain.Generics;

namespace WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;

public interface IGenericWriteRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
