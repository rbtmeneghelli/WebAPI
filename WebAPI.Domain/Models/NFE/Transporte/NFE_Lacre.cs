using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Transporte;

public sealed record NFE_Lacre
{
    [JsonProperty("nLacre")]
    public string Nlacre { get; set; }
}
