using WebAPI.DesignPatterns.AbstractFactory.Passo_1;

namespace WebAPI.DesignPatterns.AbstractFactory.Passo_3;

// Abstract Factory
public abstract class AutoSocorroFactory
{
    public abstract Guincho CriarGuincho();
    public abstract Veiculo CriarVeiculo(string modelo, Porte porte);
}