namespace WebAPI.Domain.Models;

public record FirebaseNotification
{
    [JsonPropertyName("notification")]
    public FirebaseNotificationDetails Notification { get; set; }
}

public record FirebaseNotificationDetails
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("body")]
    public string Body { get; set; }

    public FirebaseNotificationDetails()
    {

    }

    public FirebaseNotificationDetails(string title, string body)
    {
        this.Title = title;
        this.Body = body;
    }
}