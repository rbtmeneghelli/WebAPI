using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Data.Mapping;

public class StatesMapping : GenericMapping<States>
{
    public override void Configure(EntityTypeBuilder<States> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("States");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
        _builder.Property(x => x.Initials).IsRequired().HasMaxLength(5).HasColumnName("Initials");
        _builder.HasOne(x => x.Region).WithMany(x => x.States).HasForeignKey(x => x.RegionId);
    }
}
