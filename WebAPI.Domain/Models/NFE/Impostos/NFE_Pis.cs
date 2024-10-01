using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_PIS
{
    [JsonPropertyName("tipo")]
    public string Pis_Tipo { get; set; }
    [JsonPropertyName("CST")]
    public string Pis_CST { get; set; }
    [JsonPropertyName("vBC")]
    public string Pis_Vbc { get; set; }
    [JsonPropertyName("pPIS")]
    public string Pis_Ppis { get; set; }
    [JsonPropertyName("vPIS")]
    public string Pis_Vpis { get; set; }
}
