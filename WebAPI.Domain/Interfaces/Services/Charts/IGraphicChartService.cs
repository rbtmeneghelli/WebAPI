using WebAPI.Domain.Models.Factory.Charts;

namespace WebAPI.Domain.Interfaces.Services.Charts;

public interface IGraphicChartService
{
    void CreateBarGraphic(GraphicBarModel graphicModel);
    void CreateLineGraphic(GraphicLineModel graphicModel);
    void CreatePieGraphic(GraphicPieModel graphicModel);
}
