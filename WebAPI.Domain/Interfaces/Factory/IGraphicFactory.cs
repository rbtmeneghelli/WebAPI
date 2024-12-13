using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Services.Charts;

namespace WebAPI.Domain.Interfaces.Factory;

public interface IGraphicFactory
{
    IGraphicChartService GetInterfaceGraphic(EnumTypeGraphic enumGraphic);
}
