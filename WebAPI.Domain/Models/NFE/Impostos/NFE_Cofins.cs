using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_COFINS
{
    [JsonPropertyName("tipo")]
    public string Cofins_Tipo { get; set; }
    [JsonPropertyName("CST")]
    public string Cofins_Cst { get; set; }
    [JsonPropertyName("vBC")]
    public string Cofins_Vbc { get; set; }
    [JsonPropertyName("pCOFINS")]
    public string Cofins_Pcofins { get; set; }
    [JsonPropertyName("vCOFINS")]
    public string Cofins_Vcofins { get; set; }
}
