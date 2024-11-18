using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.InfraStructure.Data.Generic;

public abstract class GenericMapping<T> : IEntityTypeConfiguration<T> where T : GenericEntity, new()
{
    protected EntityTypeBuilder<T> _builder;

    public abstract void Configure(EntityTypeBuilder<T> builder);

    public abstract void ConfigureTableName(string tableName);

    public virtual void ConfigureDefaultColumns()
    {
        _builder.HasKey(x => x.Id);
        _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        _builder.Property(x => x.CreateDate).HasDefaultValue(DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()).HasColumnName("CreateDate");
        _builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        _builder.Property(x => x.Status).IsRequired().HasDefaultValue(true).HasColumnName("Status");

        // Configure Order Columns in Table
        _builder.Property(x => x.Id).HasColumnOrder(0);
        _builder.Property(x => x.CreateDate).HasColumnOrder(1);
        _builder.Property(x => x.UpdateDate).HasColumnOrder(2);
        _builder.Property(x => x.Status).HasColumnOrder(3);
    }
}
