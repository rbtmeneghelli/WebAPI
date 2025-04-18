using WebAPI.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping;

public class CepsMapping : BaseMappingModel<AddressData>
{
    public override void Configure(EntityTypeBuilder<AddressData> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Cep");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Cep).IsRequired().HasMaxLength(255).HasColumnName("Cep");
        _builder.Property(x => x.Street).HasMaxLength(255).HasColumnName("Address");
        _builder.Property(x => x.Complement).HasMaxLength(255).HasColumnName("Complement");
        _builder.Property(x => x.District).HasMaxLength(255).HasColumnName("District");
        _builder.Property(x => x.Uf).IsRequired().HasMaxLength(2).HasColumnName("Uf");
        _builder.Property(x => x.Ibge).HasMaxLength(255).HasColumnName("Ibge");
        _builder.Property(x => x.Gia).HasMaxLength(255).HasColumnName("Gia");
        _builder.Property(x => x.Ddd).HasMaxLength(255).HasColumnName("Ddd");
        _builder.Property(x => x.Siafi).HasMaxLength(255).HasColumnName("Siafi");
        _builder.HasOne(x => x.State).WithMany(x => x.Ceps).HasForeignKey(x => x.StateId);
    }
}