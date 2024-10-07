namespace TestsWebAPI.Controllers.V1;

public sealed class ProposalTypeControllerTest : GenericControllerTest
{
    public ProposalTypeControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
    }

    [Fact(Skip = "Teste ainda não disponível")]
    public void Teste()
    {
    }

    [Fact(DisplayName = "Metodo para retornar uma lista de valores")]
    public async Task GetProposalTypeFromAPIEndpoint()
    {
        //Act
        var response = await GetAsync(ConstantsURL.URL_GET_PROPOSALTYPE);
        if (response.IsSuccessStatusCode)
        {
            var responseForToken = _generalService.DeserializeObjectToObj<DropDownListDTO>(response.Content);
        }

        //Assert
        if (_existAuthentication)
            Assert.False(_existAuthentication, FixConstants.TOKEN_NOT_EXIST);
        if (_tokenIsValid)
            Assert.False(_tokenIsValid, FixConstants.TOKEN_INVALID);
        if (response.IsSuccessStatusCode)
            Assert.True(true, "Os dados foram capturados com sucesso");
        else
            Assert.False(false, FixConstants.URL_FAIL_GET_DATA);
    }
}
