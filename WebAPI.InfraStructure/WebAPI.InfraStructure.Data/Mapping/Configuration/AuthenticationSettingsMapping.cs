using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.InfraStructure.Data.Generic;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class AuthenticationSettingsMapping : GenericMapping<AuthenticationSettings>
{
    public override void Configure(EntityTypeBuilder<AuthenticationSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_AuthenticationSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.NumberOfTryToBlockUser).IsRequired().HasColumnName("NumberOfTryToBlockUser");
        _builder.Property(x => x.BlockUserTime).IsRequired().HasColumnName("BlockUserTime");
        _builder.Property(x => x.ApplyTwoFactoryValidation).IsRequired().HasDefaultValue(false).HasColumnName("ApplyTwoFactoryValidation");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.AuthenticationSettings).HasForeignKey<AuthenticationSettings>(x => x.IdEnvironmentType);
    }
}