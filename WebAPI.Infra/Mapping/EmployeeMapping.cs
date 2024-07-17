using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Data.Mapping;

public class EmployeeMapping : GenericMapping<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Employees");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(500).HasColumnName("Name");
        _builder.Property(x => x.Email).IsRequired().HasMaxLength(80).HasColumnName("Email");
        _builder.Property(x => x.TelPhone).IsRequired().HasMaxLength(20).HasColumnName("Description");
        _builder.Property(x => x.CelPhone).IsRequired().HasMaxLength(20).HasColumnName("Description");
        _builder.HasOne(x => x.Profile).WithMany(x => x.Employees).HasForeignKey(x => x.IdProfile);
        _builder.HasOne(x => x.User).WithOne(x => x.Employee);
    }
}