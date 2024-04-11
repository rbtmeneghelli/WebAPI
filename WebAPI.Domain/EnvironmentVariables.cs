using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebAPI.Domain;

public static class EnvironmentVariableConfig
{
    public static void AddEnvironmentVariablesValues(this IServiceCollection services)
    {
        if (!EnvironmentVariables.LoadEnvironmentVariables())
        {
            throw new ApplicationException("Application End. Erro: Váriaveis de ambiente ausentes.");
        }

        Action<EnvironmentVariables> resultValues = (opt =>
        {

            #region Variavel do JSON da APP
            opt.varJson = Environment.GetEnvironmentVariable("variavelJson").ToString();
            #endregion

            #region Variavel registrada na maquina
            opt.varJson = Environment.GetEnvironmentVariable("variavelMachine").ToString();
            #endregion
        });

        services.Configure(resultValues);
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EnvironmentVariables>>().Value);
    }
}

public class EnvironmentVariables
{
    public string varJson { get; set; }
    public string varMachine { get; set; }

    public static bool LoadEnvironmentVariables()
    {
        bool variaveisAmbValidas = true;

        Dictionary<string, string> variaveisAmbiente = new Dictionary<string, string>
        {
            { "variavelJson", Environment.GetEnvironmentVariable("variavelJson", EnvironmentVariableTarget.Process) },
            { "variavelMachine", Environment.GetEnvironmentVariable("variavelMachine", EnvironmentVariableTarget.User) }
        };

        variaveisAmbiente.AsParallel().ForAll(variavel =>
        {
            if (string.IsNullOrEmpty(variavel.Value))
            {
                variaveisAmbValidas = false;
                Console.WriteLine($"Variável de ambiente {variavel.Key} ausente.");
            }
        });

        return variaveisAmbValidas;
    }

    public static void SetEnvironmentVariables()
    {
        // Escrevendo variáveis de ambiente do JSON
        Environment.SetEnvironmentVariable("variavelJson", "valor da variavel json", EnvironmentVariableTarget.Process);

        // Lendo variáveis de ambiente da maquina
        Environment.SetEnvironmentVariable("variavelMachine", "valor da variavel maquina", EnvironmentVariableTarget.User);
    }
}
