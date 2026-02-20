namespace TestsWebAPI.Controllers.V1;

public sealed class AuthenticateTestControllerTest : GenericControllerTest
{
    public AuthenticateTestControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
    }

    [Theory(DisplayName = "Autenticação de usuario")]
    [InlineData("teste@gmail.com", "Teste@456")]
    [Trait("Metodo Authenticate", "Parametros (Login e Senha)")]
    public async Task Authenticate(string user, string password)
    {
        if (_authenticateEntityService.ExistAuthentication() == false)
        {
            _authenticateEntityService.InsertDefaultAuthenticate();
        }

        var login = new Login(user, password);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(90));

        var response = await _httpClient.PostAsync(ConstantsURL.URL_AUTHENTICATE, GetParamsToBase64<Login>(login), cts.Token);

        if (response.IsSuccessStatusCode)
        {

            var responseForToken = _generalService.DeserializeObjectToObj<ResponseForToken>(response.Content);
            if (responseForToken.Success)
            {
                AuthenticateEntity authenticateEntity = _authenticateEntityService.GetAuthenticate();
                authenticateEntity.Token = responseForToken.Data.Token;
                authenticateEntity.Data = FixConstants.GetDateTimeNowFromBrazil();
                authenticateEntity.InitialHour = FixConstants.GetDateTimeNowFromBrazil().TimeOfDay;
                authenticateEntity.FinalHour = FixConstants.GetDateTimeNowFromBrazil().AddHours(2).TimeOfDay;
                _authenticateEntityService.UpdateAuthenticate(authenticateEntity);
            }
        }
        else
        {
            Assert.False(false, FixConstants.URL_AUTHENTICATE_FAIL);
        }
    }

    [Theory(DisplayName = "Metodo para buscar o usuario Autenticado no banco de dados")]
    [InlineData(1)]
    public void ExistAuthUserById(int authId)
    {
        // Act
        var result = _authenticateEntityService.GetAuthenticate(authId);

        // Assert
        if (result is not null)
            Assert.Equal(1L, result.Id);
        else
            Assert.False(false);
    }

    [Fact(DisplayName = "Verificar se o usuario de autenticação está com o token valido")]
    public void UserIsAuthenticated()
    {
        Assert.True(_tokenIsValid, "Token validado com sucesso");
    }
}
