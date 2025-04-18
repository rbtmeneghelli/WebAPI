using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class EmailTemplateMapping : BaseMappingModel<EmailTemplate>
{
    public override void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_EmailTemplateSettings");
        ConfigureColumns();
        ConfigureRelationShip();
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