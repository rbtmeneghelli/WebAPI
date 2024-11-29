using WebAPI_VerticalSliceArc.Domain.Generics;

namespace WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;

public interface IGenericReadRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(long id);
}
