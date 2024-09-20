using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Mapping.Configuration;

public class RequiredPasswordSettingsMapping : GenericMapping<RequiredPasswordSettings>
{
    public override void Configure(EntityTypeBuilder<RequiredPasswordSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_RequiredPasswordSettings");
        ConfigureColumns();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
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