using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Mapping.Configuration;

public class ExpirationPasswordSettingsMapping : GenericMapping<ExpirationPasswordSettings>
{
    public override void Configure(EntityTypeBuilder<ExpirationPasswordSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_ExpirationPasswordSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.QtyDaysPasswordExpire).IsRequired().HasColumnName("QtyDaysPasswordExpire");
        _builder.Property(x => x.NotifyExpirationDays).IsRequired().HasColumnName("NotifyExpirationDays");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.ExpirationPasswordSettings).HasForeignKey<ExpirationPasswordSettings>(x => x.IdEnvironmentType);
    }
}

