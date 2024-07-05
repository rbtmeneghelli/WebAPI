using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Infra.Data.Mapping;

public class EmailTypeMapping : GenericMapping<EmailType>
{
    public override void Configure(EntityTypeBuilder<EmailType> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("EmailType");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("Description");
        _builder.Property(x => x.SmtpConfig).IsRequired().HasMaxLength(80).HasColumnName("SmtpConfig");
    }
}