using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using WebAPI.Application.Generic;

namespace WebAPI.Application.Services;

public class FirebaseService : GenericService, IFirebaseService
{ 
    private readonly IHttpClientFactory _httpClientFactory;

    public FirebaseService(INotificationMessageService notificationMessageService, IHttpClientFactory httpClientFactory) : base(notificationMessageService)
    {
        _httpClientFactory = httpClientFactory;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task SendPushNotification(string deviceClientToken, string message)
    {
        RequestData requestDataDto = new RequestData();

        string jsonData = JsonConvert.SerializeObject(new
        {
            message = new FirebaseNotification()
            {
                Notification = new FirebaseNotificationDetails()
                {
                    Title = "WebAPI_Notification",
                    Body = message
                }
            },
            token = deviceClientToken
        });

        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        try
        {
            var client = _httpClientFactory.CreateClient("Signed");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + "SERVER_KEY");
            client.Timeout = TimeSpan.FromMinutes(1);
            var response = await client.PostAsync(FixConstants.URL_TO_GET_FIREBASE, content);
            if (response.IsSuccessStatusCode)
            {
                requestDataDto.Data = await response.Content.ReadAsStringAsync();
                requestDataDto.IsSuccess = true;
            }
            else
            {
                requestDataDto.Data = $"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_FIREBASE}";
                requestDataDto.IsSuccess = false;
            }
        }
        catch
        {
            requestDataDto.Data = $"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_FIREBASE}";
            requestDataDto.IsSuccess = false;
        }
    }

}
