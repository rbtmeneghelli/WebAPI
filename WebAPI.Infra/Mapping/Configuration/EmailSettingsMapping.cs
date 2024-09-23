using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Mapping.Configuration;

public class EmailSettingsMapping : GenericMapping<EmailSettings>
{
    public override void Configure(EntityTypeBuilder<EmailSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_EmailSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Host).IsRequired().HasMaxLength(80).HasColumnName("Host");
        _builder.Property(x => x.SmtpConfig).IsRequired().HasMaxLength(80).HasColumnName("SmtpConfig");
        _builder.Property(x => x.PrimaryPort).IsRequired().HasMaxLength(3).HasColumnName("PrimaryPort");
        _builder.Property(x => x.Email).IsRequired().HasMaxLength(80).HasColumnName("Email");
        _builder.Property(x => x.Password).IsRequired().HasMaxLength(40).HasColumnName("Password");
        _builder.Property(x => x.EnableSsl).IsRequired().HasMaxLength(80).HasColumnName("EnableSsl");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithMany(p => p.EmailSettings).HasForeignKey(x => x.IdEnvironmentType);
    }
}