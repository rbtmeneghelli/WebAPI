using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.InfraStructure.Data.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel
{
    public class OperationMapping : GenericMapping<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            _builder = builder;
            base.ConfigureDefaultColumns();
            _builder.ToTable("ControlPanel_Operation");
        }

        public override void ConfigureTableName(string tableName)
        {
            _builder.ToTable(tableName);
        }
    }
}
