using DefaultWebApiTest.Services;
using Moq;

namespace TestsWebAPI.Controllers.V1;

public class AuthenticateTestControllerTest : GenericControllerTest
{
    public AuthenticateTestControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
    }

    [Theory(DisplayName = "Autenticação de usuario")]
    [InlineData("teste@gmail.com", "Teste@456")]
    [Trait("Metodo Authenticate", "Parametros (Login e Senha)")]
    public void Authenticate(string user, string password)
    {
        string url = GetUrl(ConstantsURL.URL_AUTHENTICATE);

        if (_authenticateEntityService.ExistAuthentication() == false)
        {
            _authenticateEntityService.InsertDefaultAuthenticate();
        }

        var login = new Login(user, password);

        var response = _httpClient.PostAsync(url, GetParamsToBase64<Login>(login)).GetAwaiter().GetResult();

        if (IsSuccessStatusCode(response))
        {

            var responseForToken = _generalService.DeserializeObjectToObj<ResponseForToken>(response.Content);
            if (responseForToken.Success)
            {
                AuthenticateEntity authenticateEntity = _authenticateEntityService.GetAuthenticate();
                authenticateEntity.Token = responseForToken.Data.Token;
                authenticateEntity.Data = Constants.GetDateTimeNowFromBrazil();
                authenticateEntity.HoraInicial = Constants.GetDateTimeNowFromBrazil().TimeOfDay;
                authenticateEntity.HoraFinal = Constants.GetDateTimeNowFromBrazil().AddHours(2).TimeOfDay;
                _authenticateEntityService.UpdateAuthenticate(authenticateEntity);
            }
        }
        else
        {
            Assert.True(false, Constants.URL_AUTHENTICATE_FAIL);
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
}
