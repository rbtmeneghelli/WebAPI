using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Transporte;

public class NFE_Transporta
{
    [JsonProperty("CNPJ")]
    public string Cnpj { get; set; }
    [JsonProperty("xNome")]
    public string Nome { get; set; }
    [JsonProperty("IE")]
    public string IE { get; set; }
    [JsonProperty("xEnder")]
    public string Endereco { get; set; }
    [JsonProperty("xMun")]
    public string Municipio { get; set; }
    [JsonProperty("UF")]
    public string UF { get; set; }
}
