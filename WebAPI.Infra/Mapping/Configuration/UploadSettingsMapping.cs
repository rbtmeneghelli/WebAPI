﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Mapping.Configuration;

public class UploadSettingsMapping : GenericMapping<UploadSettings>
{
    public override void Configure(EntityTypeBuilder<UploadSettings> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        ConfigureTableName("Configuration_UploadSettings");
        ConfigureColumns();
        ConfigureRelationShip();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.LogoWeb).IsRequired().HasColumnType("varbinary(max)").HasColumnName("LogoWeb");
        _builder.Property(x => x.LogoWebDescription).IsRequired().HasMaxLength(80).HasColumnName("LogoWebDescription");
        _builder.Property(x => x.LogoMobile).IsRequired().HasColumnType("varbinary(max)").HasColumnName("LogoMobile");
        _builder.Property(x => x.LogoMobileDescription).IsRequired().HasMaxLength(80).HasColumnName("LogoMobileDescription");
        _builder.Property(x => x.BannerWeb).IsRequired().HasColumnType("varbinary(max)").HasColumnName("BannerWeb");
        _builder.Property(x => x.BannerWebDescription).IsRequired().HasMaxLength(80).HasColumnName("BannerWebDescription");
        _builder.Property(x => x.BannerMobile).IsRequired().HasColumnType("varbinary(max)").HasColumnName("BannerMobile");
        _builder.Property(x => x.BannerMobileDescription).IsRequired().HasMaxLength(80).HasColumnName("BannerMobileDescription");
    }

    private void ConfigureRelationShip()
    {
        _builder.HasOne(x => x.EnvironmentTypeSettings).WithOne(p => p.UploadSettings).HasForeignKey<UploadSettings>(x => x.IdEnvironmentType);
    }
}