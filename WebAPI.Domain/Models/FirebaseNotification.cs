using Newtonsoft.Json;

namespace WebAPI.Domain.Models
{
    public sealed class FirebaseNotification
    {
        [JsonProperty("notification")]
        public FirebaseNotificationDetails Notification { get; set; }
    }

    public sealed class FirebaseNotificationDetails
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
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
}