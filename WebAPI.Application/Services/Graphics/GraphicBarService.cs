using WebAPI.Application.Services.Graphics;
using WebAPI.Domain.Interfaces.Services;

public class GraphicBarService : IGraphicBarService
{
    public void BuildGraphic(GraphicBarModel graphic)
    {
        var abc = new GraphicBarModel("a", "a");
        abc.BuildGraphic(); //Esse metodo voce faz um override de algo que ja possui
    }

    public void CalculateGraphic(GraphicBarModel graphic)
    {
        // CALCULAR ALGO XPTO QUE E COMUM PARA TODOS OS OUTROS GRAFICOS
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

