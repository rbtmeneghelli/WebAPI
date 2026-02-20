using System.Text.Json;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Interfaces.Services.Common;

namespace WebAPI.Application.Services.Common;

public sealed class FirebaseService : BaseHandlerService, IFirebaseService
{
    private readonly IHttpClientFactory _iHttpClientFactory;

    public FirebaseService(INotificationMessageService iNotificationMessageService, IHttpClientFactory iHttpClientFactory) : base(iNotificationMessageService)
    {
        _iHttpClientFactory = iHttpClientFactory;
    }

    public async Task SendPushNotification_V1(string tokenUser, FirebaseNotificationDetails firebaseNotificationDetails)
    {
        //Build Header
        string apiKey = "XPTO_KEY";
        string postDataContentType = "application/json";
        var currentDate = DateOnlyExtension.GetDateTimeNowFromBrazil().ToLongDateString();

        //Build Notification and Token
        var postData = JsonSerializer.Serialize(new
        {
            to = tokenUser,
            firebaseNotificationDetails,
            data = new
            {
                Id = 1,
                DataResult = "Sua mensagem foi enviada com sucesso!"
            }
        });

        byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(FixConstantsUrl.URL_TO_GET_FIREBASE);
        Request.Method = "POST";
        Request.KeepAlive = false;
        Request.ContentType = postDataContentType;
        Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
        Request.ContentLength = byteArray.Length;

        Stream dataStream = Request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        WebResponse Response = Request.GetResponse();
        HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;

        if (ResponseCode == HttpStatusCode.OK)
        {
            StreamReader Reader = new StreamReader(Response.GetResponseStream());
            string responseLine = Reader.ReadToEnd();
            Reader.Close();
        }
        else if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
        {
            Notify($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_FIREBASE} \n " +
                   $"Erro: {ResponseCode.ToString()}");
        }
        else if (!ResponseCode.Equals(HttpStatusCode.OK))
        {
            Notify($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_FIREBASE} \n " +
                   $"Erro: {ResponseCode.ToString()}");
        }
    }


    public async Task SendPushNotification_V2(string deviceClientToken, string message)
    {
        RequestDataModel requestDataDto = new RequestDataModel();

        string jsonData = JsonSerializer.Serialize(new
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

        var client = _iHttpClientFactory.CreateClient("Signed");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + "SERVER_KEY");
        client.Timeout = TimeSpan.FromMinutes(1);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));

        var response = await client.PostAsync(FixConstantsUrl.URL_TO_GET_FIREBASE, content, cts.Token);

        if (response.IsSuccessStatusCode)
        {
            requestDataDto.Data = await response.Content.ReadAsStringAsync();
            requestDataDto.IsSuccess = true;
        }
        else
        {
            Notify($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_FIREBASE} \n ");
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}