using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Interfaces.Services.Charts;

namespace WebAPI.Application.Factory;

public sealed class GraphicFactory : IGraphicFactory
{
    private readonly IGraphicChartJSService _iGraphicChartJSService;
    private readonly IGraphicGoogleChartService _iGraphicGoogleChartService;

    public GraphicFactory(
        IGraphicChartJSService iGraphicChartJSService,
        IGraphicGoogleChartService iGraphicGoogleChartService
    )
    {
        _iGraphicChartJSService = iGraphicChartJSService;
        _iGraphicGoogleChartService = iGraphicGoogleChartService;
    }

    public IGraphicChartService GetInterfaceGraphic(EnumTypeGraphic enumGraphic)
    {
        return enumGraphic switch
        {
            EnumTypeGraphic.CHARTJS => _iGraphicChartJSService,
            EnumTypeGraphic.GOOGLECHART => _iGraphicGoogleChartService,
            _ => throw new ApplicationException()
        };
    }
}
