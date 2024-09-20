using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Data.Mapping;

public class EmailTemplateMapping : GenericMapping<EmailTemplate>
{
    public override void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("EmailTemplate");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("Description");
        _builder.HasMany(x => x.EmailDisplays).WithOne(x => x.EmailTemplates).HasForeignKey(x => x.EmailTemplateId);
    }
}