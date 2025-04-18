using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel;

public class ProfileMapping : BaseMappingModel<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Profile");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired(true).HasMaxLength(255).HasColumnName("Description");
    }
}