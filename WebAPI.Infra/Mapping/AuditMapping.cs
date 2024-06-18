using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Data.Mapping;

public class AuditMapping : GenericMapping<Audit>
{
    public override void Configure(EntityTypeBuilder<Audit> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.Property(x => x.TableName).IsRequired().HasMaxLength(100).HasColumnName("Table_Name");
        _builder.Property(x => x.ActionName).IsRequired().HasMaxLength(80).HasColumnName("Action_Name");
        _builder.Property(x => x.KeyValues).IsRequired(false).HasMaxLength(10000).HasColumnName("Key_Values");
        _builder.Property(x => x.OldValues).IsRequired(false).HasMaxLength(10000).HasColumnName("Old_Values");
        _builder.Property(x => x.NewValues).IsRequired(false).HasMaxLength(10000).HasColumnName("New_Values");
    }
}
