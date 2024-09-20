namespace WebAPI.Domain.Models.EnvVarSettings;

public record KissLogSettings
{
    public string OrganizationId { get; set; }
    public string ApplicationId { get; set; }
    public string ApiUrl { get; set; }
}
