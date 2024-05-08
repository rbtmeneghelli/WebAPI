namespace WebAPI.Domain.Models;

public sealed class EmailSettings
{
    public string Host { get; set; }

    public string PrimaryDomain { get; set; }

    public int PrimaryPort { get; set; }

    public string UsernameFrom { get; set; }

    public string UsernameEmail { get; set; }

    public string UserPassword { get; set; }

    public bool EnableSsl { get; set; }

    public bool IsDev { get; set; }

    public bool UseDefaultEmail { get; set; }

    public EmailSettings()
    {

    }
}
