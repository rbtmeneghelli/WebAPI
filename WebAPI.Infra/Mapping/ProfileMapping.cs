using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Data.Mapping;

public class ProfileMapping : GenericMapping<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Profiles");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired(true).HasMaxLength(255).HasColumnName("Description");
    }
}