using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Transporte;

public sealed record NFE_VeicTransp
{
    [JsonPropertyName("placa")]
    public string Placa { get; set; }
    [JsonPropertyName("UF")]
    public string UF { get; set; }
    [JsonPropertyName("RNTC")]
    public string RNTC { get; set; }
}
