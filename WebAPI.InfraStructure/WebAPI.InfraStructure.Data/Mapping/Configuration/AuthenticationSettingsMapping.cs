using FastPackForShare.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Configuration;


namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class AuthenticationSettingsMapping : BaseMappingModel<AuthenticationSettings>
{
    public override void Configure(EntityTypeBuilder<AuthenticationSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_AuthenticationSettings");
        ConfigureColumns();
        ConfigureRelationShip();
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