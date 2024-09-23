using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Mapping.Configuration;

public class EmailTemplateMapping : GenericMapping<EmailTemplate>
{
    public override void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Configuration_EmailTemplateSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("Description");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasMany(x => x.EmailDisplays).WithOne(x => x.EmailTemplates).HasForeignKey(x => x.EmailTemplateId);
    }
}