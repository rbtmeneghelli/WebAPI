using WebAPI_VerticalSlice.InfraStructure.Context;
using WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public class GenericWriteRepository<TEntity> : GenericRepository<TEntity>, IGenericWriteRepository<TEntity> where TEntity : GenericEntity
{
    public GenericWriteRepository(WebAPIDbContext dbContext) : base(dbContext) { }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity); 
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
