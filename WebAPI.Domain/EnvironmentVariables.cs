using Microsoft.Extensions.Configuration;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models.EnvVarSettings;

namespace WebAPI.Domain;

public class EnvironmentVariables
{
    public ConectionStringSettings ConnectionStringSettings { get; set; }
    public RabbitMQSettings RabbitMQSettings { get; set; }
    public KafkaSettings KafkaSettings { get; set; }    
    public ServiceBusSettings ServiceBusSettings { get; set; }
    public SendGridSettings SendGridSettings { get; set; }
    public EnumEnvironment Environment {  get; set; }

    public EnvironmentVariables()
    {
        ConnectionStringSettings = new ConectionStringSettings();
        RabbitMQSettings = new RabbitMQSettings();
        KafkaSettings = new KafkaSettings();
        ServiceBusSettings = new ServiceBusSettings();
        SendGridSettings = new SendGridSettings();
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
            { configuration.GetSection($"RabbitMQSettings:Data").Value, GetEnvironmentVariableToObject<RabbitMQSettings>(configuration.GetSection($"RabbitMQSettings:Data").Value).ToString() },
            { configuration.GetSection($"KafkaSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"KafkaSettings:Data").Value).ToString() },
            { configuration.GetSection($"ServiceBusSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"ServiceBusSettings:Data").Value).ToString() },
            { configuration.GetSection($"SendGridSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"SendGridSettings:Data").Value).ToString() },
            { configuration.GetSection($"SendGridSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"SendGridSettings:Data").Value).ToString() },
        };

        return envVariables;
    }

    public static string GetDatabaseFromEnvVar(string varName)
    {
        return Environment.GetEnvironmentVariable(varName).Replace("\\\\", "\\") ?? StringExtensionMethod.GetEmptyString();
    }

    public static string GetEnvironmentVariable(string varName)
    {
        return Environment.GetEnvironmentVariable(varName) ?? StringExtensionMethod.GetEmptyString();
    }

    public static TSource GetEnvironmentVariableToObject<TSource>(string varName)
    {
        var data = Environment.GetEnvironmentVariable(varName) ?? StringExtensionMethod.GetEmptyString();
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static TSource GetEnvironmentVariableToObject<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(string varName)
    {
        var data = Environment.GetEnvironmentVariable(varName) ?? StringExtensionMethod.GetEmptyString();
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }
}
