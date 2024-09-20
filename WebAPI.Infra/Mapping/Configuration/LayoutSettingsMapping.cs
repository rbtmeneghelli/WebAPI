using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Mapping.Configuration;

public class LayoutSettingsMapping : GenericMapping<LayoutSettings>
{
    public override void Configure(EntityTypeBuilder<LayoutSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_LayoutSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.LogoWeb).IsRequired().HasColumnType("varbinary(max)").HasColumnName("LogoWeb");
        _builder.Property(x => x.LogoMobile).IsRequired().HasColumnType("varbinary(max)").HasColumnName("LogoMobile");
        _builder.Property(x => x.BannerWeb).IsRequired().HasColumnType("varbinary(max)").HasColumnName("BannerWeb");
        _builder.Property(x => x.BannerMobile).IsRequired().HasColumnType("varbinary(max)").HasColumnName("BannerMobile");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.LayoutSettings).HasForeignKey<LayoutSettings>(x => x.IdEnvironmentType);
    }
}
