using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSlice.Domain.ExtensionsMethods;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public abstract class GenericMapping<T> : IEntityTypeConfiguration<T> where T : GenericEntity, new()
{
    protected EntityTypeBuilder<T> _builder;

    public abstract void Configure(EntityTypeBuilder<T> builder);

    public virtual void ConfigureDefaultColumns()
    {
        _builder.HasKey(x => x.Id);
        _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        _builder.Property(x => x.CreatedAt).HasDefaultValue(DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()).HasColumnName("CreatedAt");
        _builder.Property(x => x.UpdateAt).HasColumnName("UpdateAt");
        _builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");
        _builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false).HasColumnName("IsDeleted");

        // Configure Order Columns in Table
        _builder.Property(x => x.Id).HasColumnOrder(0);
        _builder.Property(x => x.CreatedAt).HasColumnOrder(1);
        _builder.Property(x => x.UpdateAt).HasColumnOrder(2);
        _builder.Property(x => x.DeletedAt).HasColumnOrder(3);
        _builder.Property(x => x.IsDeleted).HasColumnOrder(4);
    }
}