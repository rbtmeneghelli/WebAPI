namespace WebAPI.DesignPatterns.AbstractFactory.Passo_1;

// Produto Concreto
public class VeiculoPequeno : Veiculo
{
    public VeiculoPequeno(string modelo, Porte porte) : base(modelo, porte)
    {
    }
}