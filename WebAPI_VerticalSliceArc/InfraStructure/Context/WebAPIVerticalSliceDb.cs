using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSliceArc.Domain.Entities;
using WebAPI_VerticalSliceArc.InfraStructure.Mappings;

namespace WebAPI_VerticalSlice.InfraStructure.Context;

public sealed class WebAPIDbContext : DbContext
{
    public WebAPIDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityMapping());
        base.OnModelCreating(modelBuilder);
    }

    //EM CASO DE ERRO APLICAR ESSE METODO!
    //public new DbSet<T> Set<T>() where T : class
    //{
    //    return base.Set<T>();
    //}

    public DbSet<ProductEntity> Products { get; set; }
}
