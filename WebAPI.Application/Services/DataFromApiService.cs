using System.Net.Http.Json;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Models.Generic;

namespace WebAPI.Infra.CrossCutting
{
    public class GetDataFromApiService<T> : IDataFromApiService<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetDataFromApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetDataFromExternalAPI(string apiPath)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Signed");
                var response = await client.GetFromJsonAsync<T>(apiPath);
                return response;
            }
            catch (GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return default(T);
            }
        }

        public async Task<IEnumerable<T>> GetListFromExternalAPI(string apiPath)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Signed");
                var response = await client.GetFromJsonAsync<IEnumerable<T>>(apiPath);
                return response;
            }
            catch (GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return Enumerable.Empty<T>();
            }
        }

        public async Task<bool> PostFromExternalAPI(string apiPath, T data)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Signed");
                var response = await client.PostAsJsonAsync(apiPath, data);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return false;
            }
        }

        public async Task<bool> PutFromExternalAPI(string apiPath, T data)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Signed");
                var response = await client.PutAsJsonAsync(apiPath, data);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return false;
            }
        }
    }
}