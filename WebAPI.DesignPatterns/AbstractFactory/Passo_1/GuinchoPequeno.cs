using WebAPI.DesignPatterns.AbstractFactory.Passo_1;

namespace WebAPI.DesignPatterns.AbstractFactory.Passo_2;

// Produto Concreto
public class GuinchoPequeno : Guincho
{
    public GuinchoPequeno(Porte porte) : base(porte) { }

    public override void Socorrer(Veiculo veiculo)
    {
        // Processo de socorro
        Console.WriteLine("Socorrendo Carro Pequeno - Modelo " + veiculo.Modelo);
    }
}
