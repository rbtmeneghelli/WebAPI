using FastPackForShare.Extensions;
using FastPackForShare.Models;
using Microsoft.Extensions.Configuration;
using WebAPI.Domain.Models;

namespace WebAPI.Domain;

public class EnvironmentVariables
{
    public ConectionStringSettings ConnectionStringSettings { get; set; }
    public RabbitMQModel RabbitMQSettings { get; set; }
    public KafkaModel KafkaSettings { get; set; }
    public ServiceBusSettings ServiceBusSettings { get; set; }
    public SendGridModel SendGridSettings { get; set; }
    public EnumEnvironment Environment { get; set; }
    public string AzureFileShareAccountName { get; set; } = "Azure-FileShare-AccountName";
    public string AzureFileShareKeyValue { get; set; } = "Azure-FileShare-KeyValue";
    public string AzureKeyVaultUrl { get; set; } = "Azure-KeyVault-Url";
    public string AzureConnectionStringStorage { get; set; } = "CONNECTION_STRING_STORAGE";
    public TwilioModel TwilioSettings { get; set; }
    public JwtConfigModel JwtConfigSettings { get; set; }

    public EnvironmentVariables()
    {
        ConnectionStringSettings = new ConectionStringSettings();
        RabbitMQSettings = new RabbitMQModel();
        KafkaSettings = new KafkaModel();
        ServiceBusSettings = new ServiceBusSettings();
        SendGridSettings = new SendGridModel();
        JwtConfigSettings = new();
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
            { configuration.GetSection($"RabbitMQSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"RabbitMQSettings:Data").Value).ToString() },
            { configuration.GetSection($"KafkaSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"KafkaSettings:Data").Value).ToString() },
            { configuration.GetSection($"ServiceBusSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"ServiceBusSettings:Data").Value).ToString() },
            { configuration.GetSection($"SendGridSettings:Data").Value, GetEnvironmentVariable(configuration.GetSection($"SendGridSettings:Data").Value).ToString() },
            { configuration.GetSection($"WebAPI_Settings:Version").Value, GetEnvironmentVariable(configuration.GetSection($"WebAPI_Settings:Version").Value).ToString() },
            { configuration.GetSection($"WebAPI_Settings:Environment").Value, GetEnvironmentVariable(configuration.GetSection($"WebAPI_Settings:Environment").Value).ToString() },
             { configuration.GetSection($"WebAPI_Settings:Token").Value, GetEnvironmentVariable(configuration.GetSection($"WebAPI_Settings:Token").Value).ToString() },
        };

        return envVariables;
    }

    public static string GetDatabaseFromEnvVar(string varName)
    {
        return Environment.GetEnvironmentVariable(varName).Replace("\\\\", "\\") ?? string.Empty;
    }

    public static string GetEnvironmentVariable(string varName)
    {
        return Environment.GetEnvironmentVariable(varName) ?? string.Empty;
    }

    public static TSource GetEnvironmentVariableToObject<TSource>(string varName)
    {
        var data = Environment.GetEnvironmentVariable(varName) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static TSource GetEnvironmentVariableToObject<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(string varName)
    {
        var data = Environment.GetEnvironmentVariable(varName) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }
}
