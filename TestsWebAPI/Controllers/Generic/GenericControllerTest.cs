using System.Text;

namespace TestsWebAPI.Controllers.Generic;

public abstract class GenericControllerTest : IClassFixture<BuilderServiceProvider>
{
    protected ServiceProvider _serviceProvider;
    protected readonly IAuthenticateEntityServiceTest _authenticateEntityService;
    protected string _authToken = string.Empty;
    protected readonly HttpClient _httpClient;
    protected readonly HttpClient _httpClientAuthentication;
    protected readonly IGeneralServiceTest _generalService;

    public GenericControllerTest(BuilderServiceProvider builderServiceProvider)
    {
        _serviceProvider = builderServiceProvider.ServiceProvider;
        _authenticateEntityService = GetAuthenticateEntityService();
        _httpClient = GetHttpClientFactoryService();
        _httpClientAuthentication = GetHttpClientFactoryService();
        _generalService = GetGeneralService();

        if (_authenticateEntityService.ExistAuthentication())
        {
            AuthenticateEntity authenticationEntity = _authenticateEntityService.GetAuthenticate(1L);
            if (_authenticateEntityService.IsValidAuthentication(authenticationEntity))
                SetTokenAuthentication(authenticationEntity.Token);
        }
        else
        {
            throw new Exception(Constants.TOKEN_NOT_EXIST);
        }
    }

    private void SetTokenAuthentication(string token) => _httpClientAuthentication.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    private IAuthenticateEntityServiceTest GetAuthenticateEntityService() => _serviceProvider.GetService<IAuthenticateEntityServiceTest>();
    private HttpClient GetHttpClientFactoryService() => _serviceProvider.GetService<IHttpClientFactory>().CreateClient();
    private IGeneralServiceTest GetGeneralService() => _serviceProvider.GetService<IGeneralServiceTest>();

    protected string GetUrl(string path) => $"{ConstantsURL.API_URL}{path}";

    protected StringContent GetParamsToString<T>(T data) where T : class
    {
        return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "Application/json");
    }

    protected StringContent GetParamsToBase64<T>(T data) where T : class
    {
        return new StringContent(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data))), Encoding.UTF8, "Application/json");
    }

    protected bool IsSuccessStatusCode(HttpResponseMessage response) => response.IsSuccessStatusCode;

    protected async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await _httpClientAuthentication.GetAsync(url);
    }

    protected async Task<HttpResponseMessage> PostAsync(string url, StringContent bodyContent)
    {
        return await _httpClientAuthentication.PostAsync(url, bodyContent);
    }
}
