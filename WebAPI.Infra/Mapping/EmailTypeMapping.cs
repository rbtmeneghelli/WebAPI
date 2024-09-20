using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Data.Mapping;

public class EmailTypeMapping : GenericMapping<EmailSettings>
{
    public override void Configure(EntityTypeBuilder<EmailSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Configuration_EmailType");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Host).IsRequired().HasMaxLength(80).HasColumnName("Host");
        _builder.Property(x => x.SmtpConfig).IsRequired().HasMaxLength(80).HasColumnName("SmtpConfig");
    }
}