using System.Net.Http.Json;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Models.Generic;

namespace WebAPI.Application.Services.Tools;

public class GetDataFromApiService<T> : IDataFromApiService<T> where T : class
{
    private readonly IHttpClientFactory _iHttpClientFactory;

    public GetDataFromApiService(IHttpClientFactory iHttpClientFactory)
    {
        _iHttpClientFactory = iHttpClientFactory;
    }

    public async Task<T> GetDataFromExternalAPI(string apiPath)
    {
        try
        {
            var client = _iHttpClientFactory.CreateClient("Signed");
            var response = await client.GetFromJsonAsync<T>(apiPath);
            return response;
        }
        catch (GenericException ex)
        {
            ex.ShowDefaultExceptionMessage();
            return default;
        }
    }

    public async Task<IEnumerable<T>> GetListFromExternalAPI(string apiPath)
    {
        try
        {
            var client = _iHttpClientFactory.CreateClient("Signed");
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
            var client = _iHttpClientFactory.CreateClient("Signed");
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
            var client = _iHttpClientFactory.CreateClient("Signed");
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

    public async Task<RequestData> RequestDataToExternalAPIAsync(string url)
    {
        RequestData requestDataDto = new RequestData();

        try
        {
            var client = _iHttpClientFactory.CreateClient("Signed");
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                requestDataDto.Data = await response.Content.ReadAsStringAsync();
                requestDataDto.IsSuccess = true;
                return requestDataDto;
            }
        }
        catch
        {
            requestDataDto.Data = $"{FixConstants.EXCEPTION_REQUEST_API} {url}";
            requestDataDto.IsSuccess = false;
        }
        return requestDataDto;
    }

    public async Task<RequestData> RequestLoginAsync(string url, string key = "")
    {
        RequestData requestDataDto = new RequestData();
        try
        {
            var client = _iHttpClientFactory.CreateClient("Signed");
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1);
            var stringContent = new StringContent(key, Encoding.UTF8, "application/xml");
            HttpResponseMessage response = await client.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                requestDataDto.Data = await response.Content.ReadAsStringAsync();
                requestDataDto.IsSuccess = true;
            }
            else
            {
                requestDataDto.Data = $"{FixConstants.EXCEPTION_REQUEST_API} {url}";
                requestDataDto.IsSuccess = false;
            }
            return requestDataDto;
        }
        catch
        {
            requestDataDto.Data = $"{FixConstants.EXCEPTION_REQUEST_API} {url}";
            requestDataDto.IsSuccess = false;
        }
        return requestDataDto;
    }
}