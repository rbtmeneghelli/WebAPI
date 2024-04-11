using WebAPI.DesignPatterns.AbstractFactory.Passo_1;

namespace WebAPI.DesignPatterns.AbstractFactory.Passo_2;

public class VeiculoCreator
{
    public static Veiculo Criar(string modelo, Porte porte)
    {
        switch (porte)
        {
            case Porte.Pequeno:
                return new VeiculoPequeno(modelo, porte);
            case Porte.Medio:
                return new VeiculoMedio(modelo, porte);
            case Porte.Grande:
                return new VeiculoGrande(modelo, porte);
            default:
                throw new ApplicationException("Porte de veiculo desconhecido.");
        }
    }
}