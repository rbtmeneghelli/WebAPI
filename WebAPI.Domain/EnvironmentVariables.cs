using Microsoft.Extensions.Configuration;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models;

namespace WebAPI.Domain;

public class EnvironmentVariables
{
    public ConnectionStringSettings ConnectionStringSettings { get; set; }

    public EnvironmentVariables()
    {
        ConnectionStringSettings = new ConnectionStringSettings();
    }

    public static bool LoadEnvironmentVariables(IConfiguration configuration)
    {
        bool environmentVariables_IsOK = true;

        EnvironmentVariablesExtension.GetEnvironmentVariablesList(configuration).AsParallel().ForAll(variavel =>
        {
            if (string.IsNullOrEmpty(variavel.Value))
            {
                environmentVariables_IsOK = false;
                Console.WriteLine($"Variável de ambiente {variavel.Key} ausente.");
            }
        });

        return environmentVariables_IsOK;
    }
}

public static class EnvironmentVariablesExtension
{
    public static Dictionary<string, string> GetEnvironmentVariablesList(IConfiguration configuration)
    {
        Dictionary<string, string> envVariables = new Dictionary<string, string>
        {
            { configuration.GetSection($"ConnectionStrings:DefaultConnection").Value, GetDatabaseFromEnvVar(configuration.GetSection($"ConnectionStrings:DefaultConnection").Value).ToString() },
            { configuration.GetSection($"ConnectionStrings:DefaultConnectionLogs").Value, GetDatabaseFromEnvVar(configuration.GetSection($"ConnectionStrings:DefaultConnectionLogs").Value).ToString() },
            { configuration.GetSection($"ConnectionStrings:DefaultConnectionToDocker").Value, GetDatabaseFromEnvVar(configuration.GetSection($"ConnectionStrings:DefaultConnectionToDocker").Value).ToString() },
            { configuration.GetSection($"ConnectionStrings:DefaultConnectionToMongoDb").Value, GetDatabaseFromEnvVar(configuration.GetSection($"ConnectionStrings:DefaultConnectionToMongoDb").Value).ToString() },
        };

        return envVariables;
    }

    public static string GetDatabaseFromEnvVar(string varName)
    {
        return Environment.GetEnvironmentVariable(varName).Replace("\\\\", "\\") ?? StringExtensionMethod.GetEmptyString();
    }

    public static TSource GetEnvironmentVariableToObject<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? StringExtensionMethod.GetEmptyString();
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? StringExtensionMethod.GetEmptyString();
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }
}
