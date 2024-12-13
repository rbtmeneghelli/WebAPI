using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IDataFromApiService<T> where T : class
{
    Task<T> GetDataFromExternalAPI(string apiPath);
    Task<IEnumerable<T>> GetListFromExternalAPI(string apiPath);
    Task<bool> PostFromExternalAPI(string apiPath, T data);
    Task<bool> PutFromExternalAPI(string apiPath, T data);
    Task<RequestData> RequestDataToExternalAPIAsync(string url);
    Task<RequestData> RequestLoginAsync(string url, string key = "");
}
