using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Mapping.Configuration;

public class EnvironmentTypeSettingsMapping : GenericMapping<EnvironmentTypeSettings>
{
    public override void Configure(EntityTypeBuilder<EnvironmentTypeSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_EnvironmentTypeSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(120).HasColumnName("Description");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(3).HasColumnName("Initials");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EmailSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<EmailSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.ExpirationPasswordSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<ExpirationPasswordSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.RequiredPasswordSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<RequiredPasswordSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.AuthenticationSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<AuthenticationSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.LayoutSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<LayoutSettings>(x => x.IdEnvironmentType);
        _builder.HasOne(x => x.LogSettings).WithOne(p => p.EnvironmentTypeSettings).HasForeignKey<LogSettings>(x => x.IdEnvironmentType);
    }
}
