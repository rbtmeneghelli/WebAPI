namespace WebAPI.Domain.Models.EnvVarSettings;

public sealed record TwilioSettings
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string TwilioNumber { get; set; }
}
