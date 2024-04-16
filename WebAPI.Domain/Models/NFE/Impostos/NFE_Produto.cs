using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_Produto
{
    [JsonProperty("cProd")]
    public string Produto_Cprod { get; set; }
    [JsonProperty("xProd")]
    public string Produto_Xprod { get; set; }
    [JsonProperty("CFOP")]
    public string Produto_Cfop { get; set; }
    [JsonProperty("uCom")]
    public string Produto_Ucom { get; set; }
    [JsonProperty("qCom")]
    public string Produto_Qcom { get; set; }
    [JsonProperty("vUnCom")]
    public string Produto_Vuncom { get; set; }
    [JsonProperty("vProd")]
    public string Produto_Vprod { get; set; }
    [JsonProperty("uTrib")]
    public string Produto_Utrib { get; set; }
    [JsonProperty("qTrib")]
    public string Produto_Qtrib { get; set; }
    [JsonProperty("vUnTrib")]
    public string Produto_Vuntrib { get; set; }
}
