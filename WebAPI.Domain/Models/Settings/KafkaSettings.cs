namespace WebAPI.Domain.Models.Settings;

public sealed record KafkaSettings
{
    public string BootstrapServers { get; set; }
}
