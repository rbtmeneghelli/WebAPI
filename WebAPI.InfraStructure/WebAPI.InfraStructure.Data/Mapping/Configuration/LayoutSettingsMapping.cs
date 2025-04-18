using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class LayoutSettingsMapping : BaseMappingModel<LayoutSettings>
{
    public override void Configure(EntityTypeBuilder<LayoutSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_LayoutSettings");
        ConfigureColumns();
        ConfigureRelationShip();

        _builder.ToTable("Configuration_LayoutSettings", e => e.IsTemporal(t =>
        {
            t.HasPeriodStart("InicioValidade");
            t.HasPeriodEnd("TerminoValidade");
            t.UseHistoryTable("Configuration_LayoutSettingsHistory");
        }));
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.ImageFileContentToUpload).IsRequired().HasMaxLength(80).HasColumnName("ImageFileContentToUpload");
        _builder.Property(x => x.DocumentFileContentToUpload).IsRequired().HasMaxLength(80).HasColumnName("DocumentFileContentToUpload");
        _builder.Property(x => x.MaxImageFileSize).IsRequired().HasDefaultValue(20).HasColumnName("MaxImageFileSize");
        _builder.Property(x => x.MaxDocumentFileSize).IsRequired().HasDefaultValue(20).HasColumnName("MaxDocumentFileSize");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.LayoutSettings).HasForeignKey<LayoutSettings>(x => x.IdEnvironmentType);
    }
}
