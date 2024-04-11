using WebAPI.DesignPatterns.AbstractFactory.Passo_1;

namespace WebAPI.DesignPatterns.AbstractFactory.Passo_2;

public class GuinchoCreator
{
    public static Guincho Criar(Porte porte)
    {
        switch (porte)
        {
            case Porte.Pequeno:
                return new GuinchoPequeno(porte);
            case Porte.Medio:
                return new GuinchoMedio(porte);
            case Porte.Grande:
                return new GuinchoGrande(porte);
            default:
                throw new ApplicationException("Porte de Guincho desconhecido.");
        }
    }
}
