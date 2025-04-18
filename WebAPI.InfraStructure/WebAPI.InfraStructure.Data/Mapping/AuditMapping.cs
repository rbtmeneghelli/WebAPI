using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Others;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping;

public class AuditMapping : BaseMappingModel<Audit>
{
    public override void Configure(EntityTypeBuilder<Audit> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Audit");
        ConfigureColumns();
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
