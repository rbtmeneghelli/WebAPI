using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel;

public class EmployeeMapping : BaseMappingModel<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Employee");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(500).HasColumnName("Name");
        _builder.Property(x => x.Email).IsRequired().HasMaxLength(80).HasColumnName("Email");
        _builder.Property(x => x.TelPhone).IsRequired().HasMaxLength(20).HasColumnName("TelPhone");
        _builder.Property(x => x.CelPhone).IsRequired().HasMaxLength(20).HasColumnName("CelPhone");
        _builder.HasOne(x => x.Profile).WithMany(x => x.Employees).HasForeignKey(x => x.IdProfile);
        _builder.HasOne(x => x.User).WithOne(x => x.Employee).HasForeignKey<Employee>(x => x.IdUser);
    }
}