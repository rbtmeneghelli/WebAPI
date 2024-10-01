using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_ICMS
{
    [JsonPropertyName("tipo")]
    public string Icms_Tipo { get; set; }
    [JsonPropertyName("orig")]
    public string Icms_Orig { get; set; }
    [JsonPropertyName("CST")]
    public string Icms_Cst { get; set; }
    [JsonPropertyName("modBC")]
    public string Icms_ModBc { get; set; }
    [JsonPropertyName("vBC")]
    public string Icms_Vbc { get; set; }
    [JsonPropertyName("pICMS")]
    public string Icms_Picms { get; set; }
    [JsonPropertyName("vICMS")]
    public string Icms_Vicms { get; set; }
}
