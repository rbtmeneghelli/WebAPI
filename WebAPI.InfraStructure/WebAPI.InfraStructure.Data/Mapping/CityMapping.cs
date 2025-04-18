using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Others;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping;

public class CityMapping : BaseMappingModel<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_City");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.IBGE).IsRequired().HasMaxLength(255).HasColumnName("Ibge");
        _builder.Property(x => x.Name).HasMaxLength(255).HasColumnName("City");
        _builder.HasOne(x => x.States).WithMany(x => x.City).HasForeignKey(x => x.StateId);
    }
}
