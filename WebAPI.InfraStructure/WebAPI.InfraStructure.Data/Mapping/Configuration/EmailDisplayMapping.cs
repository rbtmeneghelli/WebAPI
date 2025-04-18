using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class EmailDisplayMapping : BaseMappingModel<EmailDisplay>
{
    public override void Configure(EntityTypeBuilder<EmailDisplay> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_EmailDisplaySettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Title).IsRequired().HasMaxLength(255).HasColumnName("Title");
        _builder.Property(x => x.Subject).IsRequired().HasMaxLength(255).HasColumnName("Subject");
        _builder.Property(x => x.Body).IsRequired().HasMaxLength(8000).HasColumnName("Body");
        _builder.Property(x => x.MessagePriority).IsRequired().HasColumnName("Priority");
        _builder.Property(x => x.HasAttachment).IsRequired().HasDefaultValue(false).HasColumnName("HasAttachment");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EmailTemplates).WithMany(x => x.EmailDisplays).HasForeignKey(x => x.EmailTemplateId);
    }
}