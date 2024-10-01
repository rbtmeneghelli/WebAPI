namespace DefaultWebApiTest.Services;

public class GeneralServiceTest : IGeneralServiceTest
{
    public T DeserializeObjectToObj<T>(HttpContent responseBody) where T : class
    {
        var data = responseBody.ReadAsStringAsync().Result;
        return JsonSerializer.Deserialize<T>(data);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
