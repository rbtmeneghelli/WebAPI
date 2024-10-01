using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_Produto
{
    [JsonPropertyName("cProd")]
    public string Produto_Cprod { get; set; }
    [JsonPropertyName("xProd")]
    public string Produto_Xprod { get; set; }
    [JsonPropertyName("CFOP")]
    public string Produto_Cfop { get; set; }
    [JsonPropertyName("uCom")]
    public string Produto_Ucom { get; set; }
    [JsonPropertyName("qCom")]
    public string Produto_Qcom { get; set; }
    [JsonPropertyName("vUnCom")]
    public string Produto_Vuncom { get; set; }
    [JsonPropertyName("vProd")]
    public string Produto_Vprod { get; set; }
    [JsonPropertyName("uTrib")]
    public string Produto_Utrib { get; set; }
    [JsonPropertyName("qTrib")]
    public string Produto_Qtrib { get; set; }
    [JsonPropertyName("vUnTrib")]
    public string Produto_Vuntrib { get; set; }
}
