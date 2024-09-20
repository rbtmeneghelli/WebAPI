namespace WebAPI.Domain.Models.EnvVarSettings;

public sealed record RabbitMQSettings
{
    public string HostName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
