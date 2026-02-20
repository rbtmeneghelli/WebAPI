using System.Text;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Common;

namespace TestsWebAPI.Controllers.Generic;

public abstract class GenericControllerTest : IClassFixture<BuilderServiceProvider>
{
    protected ServiceProvider _serviceProvider;
    protected readonly IAuthenticateEntityServiceTest _authenticateEntityService;
    protected readonly IGeneralServiceTest _generalService;
    protected readonly HttpClient _httpClient;
    protected readonly HttpClient _httpClientAuthentication;

    protected bool _existAuthentication = false;
    protected bool _tokenIsValid = false;
    protected string _authToken = string.Empty;

    private void ApplyTokenAuthentication()
    {
        _existAuthentication = _authenticateEntityService.ExistAuthentication();

        if (_existAuthentication)
        {
            AuthenticateEntity authenticationEntity = _authenticateEntityService.GetAuthenticate(1L);
            if (_authenticateEntityService.IsValidAuthentication(authenticationEntity))
            {
                _tokenIsValid = true;
                _httpClientAuthentication.DefaultRequestHeaders.Add("Authorization", "Bearer " + authenticationEntity.Token);
            }
            else
            {
                _tokenIsValid = false;
            }
        }
    }

    public GenericControllerTest(BuilderServiceProvider builderServiceProvider)
    {
        _serviceProvider = builderServiceProvider.ServiceProvider;
        _authenticateEntityService = _serviceProvider.GetService<IAuthenticateEntityServiceTest>();
        _httpClient = _serviceProvider.GetService<IHttpClientFactory>().CreateClient();
        _httpClientAuthentication = _serviceProvider.GetService<IHttpClientFactory>().CreateClient();
        _generalService = _serviceProvider.GetService<IGeneralServiceTest>();
        ApplyTokenAuthentication();
    }

    protected StringContent GetParamsToString<T>(T data) where T : class
    {
        return new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "Application/json");
    }

    protected StringContent GetParamsToBase64<T>(T data) where T : class
    {
        return new StringContent(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data))), Encoding.UTF8, "Application/json");
    }

    protected async Task<HttpResponseMessage> GetAsync(string url)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(90));

        var requestTask = await _httpClientAuthentication.GetAsync(url, cts.Token);

        return requestTask;
    }

    protected async Task<HttpResponseMessage> PostAsync(string url, StringContent bodyContent)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(90));

        var requestTask = await _httpClientAuthentication.PostAsync(url, bodyContent, cts.Token);

        return requestTask;
    }
}
