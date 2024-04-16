using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_ICMS
{
    [JsonProperty("tipo")]
    public string Icms_Tipo { get; set; }
    [JsonProperty("orig")]
    public string Icms_Orig { get; set; }
    [JsonProperty("CST")]
    public string Icms_Cst { get; set; }
    [JsonProperty("modBC")]
    public string Icms_ModBc { get; set; }
    [JsonProperty("vBC")]
    public string Icms_Vbc { get; set; }
    [JsonProperty("pICMS")]
    public string Icms_Picms { get; set; }
    [JsonProperty("vICMS")]
    public string Icms_Vicms { get; set; }
}
