using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Generic;
using WebAPI.Domain;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Infra.Generic;

public abstract class GenericMapping<T> : IEntityTypeConfiguration<T> where T : GenericEntity, new()
{
    protected EntityTypeBuilder<T> _builder;

    public abstract void Configure(EntityTypeBuilder<T> builder);

    public virtual void ConfigureDefaultColumns()
    {
        _builder.HasKey(x => x.Id);
        _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        _builder.Property(x => x.CreatedTime).HasDefaultValue(DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()).HasColumnName("Created_Time");
        _builder.Property(x => x.UpdateTime).HasColumnName("Update_Time");
        _builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnName("Is_Active");

        // Configure Order Columns in Table
        _builder.Property(x => x.Id).HasColumnOrder(0);
        _builder.Property(x => x.CreatedTime).HasColumnOrder(1);
        _builder.Property(x => x.UpdateTime).HasColumnOrder(2);
        _builder.Property(x => x.IsActive).HasColumnOrder(3);
    }
}
