using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class EmailSettingsMapping : BaseMappingModel<EmailSettings>
{
    public override void Configure(EntityTypeBuilder<EmailSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_EmailSettings");
        ConfigureColumns();
        ConfigureRelationShip();
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