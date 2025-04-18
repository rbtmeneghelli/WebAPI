using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.InfraStructure.Data.Generic;
using WebAPI.Domain.Entities.Others;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping;

public class RegionMapping : BaseMappingModel<Region>
{
    public override void Configure(EntityTypeBuilder<Region> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Region");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(5).HasColumnName("Initials");
    }
}