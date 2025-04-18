using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel;

public class AreaMapping : BaseMappingModel<Area>
{
    public override void Configure(EntityTypeBuilder<Area> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Area");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("Description");
        _builder.Property(x => x.HierarchyLevel).IsRequired().HasConversion<string>().HasColumnName("HierarchyLevel");
        _builder.Property(x => x.Order).IsRequired().HasColumnName("Order");
        _builder.HasMany(x => x.Profiles).WithOne(x => x.Area).HasForeignKey(x => x.IdArea).OnDelete(DeleteBehavior.NoAction);
    }
}