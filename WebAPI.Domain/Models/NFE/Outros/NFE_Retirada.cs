using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Retirada
{
    [JsonProperty("CNPJ")]
    public string Cnpj { get; set; }
    [JsonProperty("xLgr")]
    public string Logradouro { get; set; }
    [JsonProperty("nro")]
    public string Numero { get; set; }
    [JsonProperty("xCpl")]
    public string Complemento { get; set; }
    [JsonProperty("xBairro")]
    public string Bairro { get; set; }
    [JsonProperty("cMun")]
    public string CodigoMunicipio { get; set; }
    [JsonProperty("xMun")]
    public string Municipio { get; set; }
    [JsonProperty("UF")]
    public string UF { get; set; }
}
