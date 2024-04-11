using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Infra.Data.Mapping;

public class RegionMapping : GenericMapping<Region>
{
    public override void Configure(EntityTypeBuilder<Region> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Regions");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(5).HasColumnName("Initials");
    }
}