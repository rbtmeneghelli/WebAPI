using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class ExpirationPasswordSettingsMapping : BaseMappingModel<ExpirationPasswordSettings>
{
    public override void Configure(EntityTypeBuilder<ExpirationPasswordSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_ExpirationPasswordSettings");
        ConfigureColumns();
        ConfigureRelationShip();
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

