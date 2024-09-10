using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI_VerticalSliceArc.Domain.Generics;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.InfraStructure.Mappings
{
    public class ProductEntityMapping : GenericMapping<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            _builder = builder;
            base.ConfigureDefaultColumns();
            _builder.ToTable("Products");
            ConfigureColumns();
        }

        private void ConfigureColumns()
        {
            _builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("Name").HasColumnOrder(5);
            _builder.Property(x => x.Price).IsRequired().HasColumnOrder(6);
        }
    }
}
