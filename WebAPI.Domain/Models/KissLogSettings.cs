namespace WebAPI.Domain.Models;

public record KissLogSettings
{
    public string OrganizationId { get; set; }
    public string ApplicationId { get; set; }
    public string ApiUrl { get; set; }
}
