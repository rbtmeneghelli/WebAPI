using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Infra.Data.Mapping;

public class StatesMapping : GenericMapping<States>
{
    public override void Configure(EntityTypeBuilder<States> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("ControlPanel_State");
        ConfigureColumns();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(5).HasColumnName("Initials");
        _builder.HasOne(x => x.Region).WithMany(x => x.States).HasForeignKey(x => x.RegionId);
    }
}
