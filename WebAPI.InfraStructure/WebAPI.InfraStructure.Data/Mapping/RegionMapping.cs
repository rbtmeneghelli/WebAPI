using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.InfraStructure.Data.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.InfraStructure.Data.Mapping;

public class RegionMapping : GenericMapping<Region>
{
    public override void Configure(EntityTypeBuilder<Region> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("ControlPanel_Region");
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
    }
}