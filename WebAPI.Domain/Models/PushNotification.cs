namespace WebAPI.Domain.Models;

public record PushNotification
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Link { get; set; }
}
