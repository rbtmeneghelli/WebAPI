// Produto Concreto
using WebAPI.DesignPatterns.AbstractFactory.Passo_1;

public class VeiculoGrande : Veiculo
{
    public VeiculoGrande(string modelo, Porte porte) : base(modelo, porte)
    {
    }
}