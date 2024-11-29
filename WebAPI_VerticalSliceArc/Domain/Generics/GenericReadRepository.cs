using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSlice.InfraStructure.Context;
using WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public class GenericReadRepository<TEntity> : GenericRepository<TEntity>, IGenericReadRepository<TEntity> where TEntity : class
{
    public GenericReadRepository(WebAPIDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }
}
