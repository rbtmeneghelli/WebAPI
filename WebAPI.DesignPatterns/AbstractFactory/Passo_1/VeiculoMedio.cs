namespace WebAPI.DesignPatterns.AbstractFactory.Passo_1;

// Produto Concreto
public class VeiculoMedio : Veiculo
{
    public VeiculoMedio(string modelo, Porte porte) : base(modelo, porte)
    {
    }
}