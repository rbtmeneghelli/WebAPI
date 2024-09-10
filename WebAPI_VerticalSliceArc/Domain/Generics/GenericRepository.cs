using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSlice.InfraStructure.Context;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public class GenericRepository<TEntity> : IDisposable where TEntity : GenericEntity
{
    private readonly WebAPIDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(WebAPIDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    protected async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    protected async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    protected async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    protected async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    protected async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}
