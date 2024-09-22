using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services.Graphics;

public class GraphicLineService : IGraphicLineService
{
    public void BuildGraphic(GraphicLineModel graphic)
    {
        var abc = new GraphicBarModel("a", "a");
        abc.BuildGraphic(); //Esse metodo voce faz um override de algo que ja possui
    }

    public void CalculateGraphic(GraphicLineModel graphic)
    {
        // CALCULAR ALGO XPTO QUE E COMUM PARA TODOS OS OUTROS GRAFICOS
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

