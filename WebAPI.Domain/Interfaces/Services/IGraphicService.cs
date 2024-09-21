using WebAPI.Domain.Models.Charts;

namespace WebAPI.Domain.Interfaces.Services;

public interface IBaseGraphicService<TGraphic> : IDisposable where TGraphic : class
{
    void BuildGraphic(TGraphic graphic);
    void CalculateGraphic(TGraphic graphic);
}


public interface IGraphicLineService : IBaseGraphicService<LineChart> 
{
}

public interface IGraphicBarService : IBaseGraphicService<BarChart>
{
}