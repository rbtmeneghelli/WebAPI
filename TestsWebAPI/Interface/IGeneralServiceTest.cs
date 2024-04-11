namespace TestsWebAPI.Interface;

public interface IGeneralServiceTest : IDisposable
{
    T DeserializeObjectToObj<T>(HttpContent responseBody) where T : class;
}
