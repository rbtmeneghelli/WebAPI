using WebAPI.DesignPatterns.AbstractFactory.Passo_1;
using WebAPI.DesignPatterns.AbstractFactory.Passo_2;
using WebAPI.DesignPatterns.AbstractFactory.Passo_4;

namespace WebAPI.DesignPatterns.AbstractFactory.Passo_5;

public class ExecucaoAbstractFactory
{
    public static void Executar()
    {
        var veiculosSocorro = new List<Veiculo>
        {
            VeiculoCreator.Criar("Celta", Porte.Pequeno),
            VeiculoCreator.Criar("Jetta", Porte.Medio),
            VeiculoCreator.Criar("BMW X6", Porte.Grande)
        };

        veiculosSocorro.ForEach(v => AutoSocorro.CriarAutoSocorro(v).RealizarAtendimento());
    }
}
