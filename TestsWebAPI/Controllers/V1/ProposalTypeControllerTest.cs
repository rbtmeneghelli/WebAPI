namespace TestsWebAPI.Controllers.V1;

public class ProposalTypeControllerTest : GenericControllerTest
{
    public ProposalTypeControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
    }

    [Fact(Skip = "Teste ainda não disponível")]
    public void Teste()
    {
    }

    [Fact(DisplayName = "Metodo para retornar uma lista de valores")]
    public void GetProposalType()
    {
        string url = GetUrl(ConstantsURL.URL_GET_PROPOSALTYPE);

        Assert.True(_authenticateEntityService.ExistAuthentication(), Constants.TOKEN_NOT_EXIST);
        AuthenticateEntity authenticateEntity = _authenticateEntityService.GetAuthenticate();
        Assert.True(_authenticateEntityService.IsValidAuthentication(authenticateEntity), Constants.TOKEN_INVALID);

        var response = GetAsync(url).GetAwaiter().GetResult();

        if (IsSuccessStatusCode(response))
        {

            var responseForToken = _generalService.DeserializeObjectToObj<ResponseForProposalTypeDTO>(response.Content);
            if (responseForToken.Success)
            {
                Assert.True(true, "Dados capturados com sucesso");
            }
        }
        else
        {
            Assert.True(false, Constants.URL_FAIL_GET_DATA);
        }
    }
}
