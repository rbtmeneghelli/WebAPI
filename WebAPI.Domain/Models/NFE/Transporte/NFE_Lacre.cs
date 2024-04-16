using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Transporte;

public sealed record Lacre
{
    [JsonProperty("nLacre")]
    public string Nlacre { get; set; }
}
