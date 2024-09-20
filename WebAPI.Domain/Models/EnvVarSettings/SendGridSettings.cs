namespace WebAPI.Domain.Models.EnvVarSettings;
public sealed record SendGridSettings
{
    public string Client { get; set; }
    public string EmailSender { get; set; }
    public string EmailSenderName { get; set; }
}