using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.Configuration;

public class LogSettingsMapping : BaseMappingModel<LogSettings>
{
    public override void Configure(EntityTypeBuilder<LogSettings> builder)
    {
        _builder = builder;
        base.ConfigureBase("Configuration_LogSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.SaveLogTurnOnSystem).IsRequired().HasDefaultValue(false).HasColumnName("SaveLogTurnOnSystem");
        _builder.Property(x => x.SaveLogTurnOffSystem).IsRequired().HasDefaultValue(false).HasColumnName("SaveLogTurnOffSystem");
        _builder.Property(x => x.SaveLogCreateData).IsRequired().HasDefaultValue(true).HasColumnName("SaveLogCreateData");
        _builder.Property(x => x.SaveLogResearchData).IsRequired().HasDefaultValue(true).HasColumnName("SaveLogResearchData");
        _builder.Property(x => x.SaveLogUpdateData).IsRequired().HasDefaultValue(true).HasColumnName("SaveLogUpdateData");
        _builder.Property(x => x.SaveLogDeleteData).IsRequired().HasDefaultValue(true).HasColumnName("SaveLogDeleteData");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.LogSettings).HasForeignKey<LogSettings>(x => x.IdEnvironmentType);
    }
}
