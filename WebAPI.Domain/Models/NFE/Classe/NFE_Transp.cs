using System.Text.Json.Serialization;
using WebAPI.Domain.Models.NFE.Transporte;

namespace WebAPI.Domain.Models.NFE.Classe;

public sealed record NFE_Transp
{
    [JsonPropertyName("modFrete")]
    public string ModFrete { get; set; }
    [JsonPropertyName("transporta")]
    public NFE_Transporta Transporta { get; set; }
    [JsonPropertyName("veicTransp")]
    public NFE_VeicTransp VeicTransp { get; set; }
    [JsonPropertyName("reboque")]
    public NFE_Reboque Reboque { get; set; }
    [JsonPropertyName("vol")]
    public NFE_Vol Vol { get; set; }
}
