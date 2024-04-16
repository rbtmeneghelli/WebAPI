using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Transporte;

public sealed record NFE_Reboque
{
    [JsonProperty("nLacre")]
    public string Placa { get; set; }
    [JsonProperty("UF")]
    public string UF { get; set; }
    [JsonProperty("RNTC")]
    public string RNTC { get; set; }
}
