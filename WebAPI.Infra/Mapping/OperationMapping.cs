using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;

namespace WebAPI.Infra.Data.Mapping
{
    public class OperationMapping : GenericMapping<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            _builder = builder;
            base.ConfigureDefaultColumns();
            _builder.ToTable("Operation");
        }
    }
}
