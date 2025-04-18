using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class EnvironmentTypeSettingsMapping : BaseMappingModel<EnvironmentTypeSettings>
{
    public override void Configure(EntityTypeBuilder<EnvironmentTypeSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_EnvironmentTypeSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(120).HasColumnName("Description");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(6).HasColumnName("Initials");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasMany(x => x.EmailSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.ExpirationPasswordSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<ExpirationPasswordSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.RequiredPasswordSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<RequiredPasswordSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.AuthenticationSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<AuthenticationSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.LayoutSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<LayoutSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.LogSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<LogSettings>(x => x.IdEnvironmentType);
    }
}
