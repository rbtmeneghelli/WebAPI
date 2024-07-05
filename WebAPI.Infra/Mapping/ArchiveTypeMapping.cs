using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Infra.Data.Mapping;

public class ArchiveTypeMapping : GenericMapping<ArchiveType>
{
    public override void Configure(EntityTypeBuilder<ArchiveType> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        _builder.ToTable("ArchiveType");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("Description");
    }
}