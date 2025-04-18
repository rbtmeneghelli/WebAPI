using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class RequiredPasswordSettingsMapping : BaseMappingModel<RequiredPasswordSettings>
{
    public override void Configure(EntityTypeBuilder<RequiredPasswordSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_RequiredPasswordSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.MinimalOfChars).IsRequired().HasColumnName("MinimalOfChars");
        _builder.Property(x => x.MustHaveUpperCaseLetter).IsRequired().HasDefaultValue(true).HasColumnName("MustHaveUpperCaseLetter");
        _builder.Property(x => x.MustHaveNumbers).IsRequired().HasDefaultValue(true).HasColumnName("MustHaveNumbers");
        _builder.Property(x => x.MustHaveSpecialChars).IsRequired().HasDefaultValue(true).HasColumnName("MustHaveSpecialChars");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.RequiredPasswordSettings).HasForeignKey<RequiredPasswordSettings>(x => x.IdEnvironmentType);
    }
}