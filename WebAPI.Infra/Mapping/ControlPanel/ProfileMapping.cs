using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Mapping.ControlPanel;

public class ProfileMapping : GenericMapping<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("ControlPanel_Profile");
        ConfigureColumns();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired(true).HasMaxLength(255).HasColumnName("Description");
    }
}