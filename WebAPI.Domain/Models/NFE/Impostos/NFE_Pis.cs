using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_PIS
{
    [JsonProperty("tipo")]
    public string Pis_Tipo { get; set; }
    [JsonProperty("CST")]
    public string Pis_CST { get; set; }
    [JsonProperty("vBC")]
    public string Pis_Vbc { get; set; }
    [JsonProperty("pPIS")]
    public string Pis_Ppis { get; set; }
    [JsonProperty("vPIS")]
    public string Pis_Vpis { get; set; }
}
