using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Transporte;

public sealed record NFE_Lacre
{
    [JsonPropertyName("nLacre")]
    public string Nlacre { get; set; }
}
