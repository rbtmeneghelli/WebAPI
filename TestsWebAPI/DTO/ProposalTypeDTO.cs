namespace TestsWebAPI.DTO;

public class ProposalTypeDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int CdProduto { get; set; }
    public int IdProdutoCobertura { get; set; }
    public decimal LimitValueIS { get; set; }
}

public class ResponseForProposalTypeDTO
{
    [JsonProperty("sucess")]
    public bool Success { get; set; }
    [JsonProperty("data")]
    public List<ProposalTypeDTO> Data { get; set; }
}
