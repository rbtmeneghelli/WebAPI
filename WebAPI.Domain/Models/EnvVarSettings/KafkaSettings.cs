namespace WebAPI.Domain.Models.EnvVarSettings;

public sealed record KafkaSettings
{
    public string BootstrapServers { get; set; }
}
