using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Transporte;

public class NFE_Transporta
{
    [JsonPropertyName("CNPJ")]
    public string Cnpj { get; set; }
    [JsonPropertyName("xNome")]
    public string Nome { get; set; }
    [JsonPropertyName("IE")]
    public string IE { get; set; }
    [JsonPropertyName("xEnder")]
    public string Endereco { get; set; }
    [JsonPropertyName("xMun")]
    public string Municipio { get; set; }
    [JsonPropertyName("UF")]
    public string UF { get; set; }
}
