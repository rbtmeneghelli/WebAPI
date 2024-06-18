using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Data.Mapping;

public class RoleMapping : GenericMapping<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("Roles");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired(true).HasMaxLength(255).HasColumnName("Description");
        _builder.Property(x => x.RoleTag).IsRequired(true).HasMaxLength(80).HasColumnName("Role");
        _builder.HasOne(x => x.Operation).WithMany(x => x.Roles).HasForeignKey(x => x.IdOperation).HasConstraintName("IdOperation");
    }
}
