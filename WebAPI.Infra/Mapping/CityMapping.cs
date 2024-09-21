using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Infra.Data.Mapping;

public class CityMapping : GenericMapping<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("ControlPanel_City");
        ConfigureColumns();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.IBGE).IsRequired().HasMaxLength(255).HasColumnName("Ibge");
        _builder.Property(x => x.Name).HasMaxLength(255).HasColumnName("City");
        _builder.HasOne(x => x.States).WithMany(x => x.City).HasForeignKey(x => x.StateId);
    }
}
