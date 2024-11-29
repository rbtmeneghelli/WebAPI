using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSlice.InfraStructure.Context;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public abstract class GenericRepository<TEntity> : IDisposable where TEntity : class
{
    protected readonly WebAPIDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(WebAPIDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}
