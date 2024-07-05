using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities;
using MimeKit;

namespace WebAPI.Infra.Data.Mapping;

public class EmailDisplayMapping : GenericMapping<EmailDisplay>
{
    public override void Configure(EntityTypeBuilder<EmailDisplay> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("EmailDisplay");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Title).IsRequired().HasMaxLength(255).HasColumnName("Title");
        _builder.Property(x => x.Subject).IsRequired().HasMaxLength(255).HasColumnName("Subject");
        _builder.Property(x => x.Body).IsRequired().HasMaxLength(8000).HasColumnName("Body");
        _builder.Property(x => x.Priority).IsRequired().HasColumnName("Priority");
        _builder.Property(x => x.HasAttachment).IsRequired().HasDefaultValue(false).HasColumnName("HasAttachment");
        _builder.HasOne(x => x.EmailTemplates).WithMany(x => x.EmailDisplays).HasForeignKey(x => x.EmailTemplateId);
    }
}