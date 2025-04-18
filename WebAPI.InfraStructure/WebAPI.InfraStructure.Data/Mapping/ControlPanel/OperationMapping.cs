using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;
using FastPackForShare.Bases;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel
{
    public class OperationMapping : BaseMappingModel<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            _builder = builder;
            base.ConfigureBase("ControlPanel_Operation");
        }
    }
}
