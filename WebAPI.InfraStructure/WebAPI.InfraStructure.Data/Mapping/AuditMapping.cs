using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.InfraStructure.Data.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.InfraStructure.Data.Mapping;

public class AuditMapping : GenericMapping<Audit>
{
    public override void Configure(EntityTypeBuilder<Audit> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("ControlPanel_Audit");
        ConfigureColumns();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.TableName).IsRequired().HasMaxLength(100).HasColumnName("TableName");
        _builder.Property(x => x.ActionName).IsRequired().HasMaxLength(80).HasColumnName("ActionName");
        _builder.Property(x => x.KeyValues).IsRequired(false).HasMaxLength(10000).HasColumnName("KeyValues");
        _builder.Property(x => x.OldValues).IsRequired(false).HasMaxLength(10000).HasColumnName("OldValues");
        _builder.Property(x => x.NewValues).IsRequired(false).HasMaxLength(10000).HasColumnName("NewValues");
    }
}
