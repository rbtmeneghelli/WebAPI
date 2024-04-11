namespace DefaultWebApiTest.Services;

public class GeneralServiceTest : IGeneralServiceTest
{
    public T DeserializeObjectToObj<T>(HttpContent responseBody) where T : class
    {
        return JsonConvert.DeserializeObject<T>(responseBody.ReadAsStringAsync().Result);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
