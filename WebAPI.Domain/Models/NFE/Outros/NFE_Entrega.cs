using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Entrega
{
    [JsonPropertyName("CNPJ")]
    public string CNPJ { get; set; }
    [JsonPropertyName("xLgr")]
    public string Logradouro { get; set; }
    [JsonPropertyName("nro")]
    public string Numero { get; set; }
    [JsonPropertyName("xCpl")]
    public string Complemento { get; set; }
    [JsonPropertyName("xBairro")]
    public string Bairro { get; set; }
    [JsonPropertyName("cMun")]
    public string CodigoMunicipio { get; set; }
    [JsonPropertyName("xMun")]
    public string Municipio { get; set; }
    [JsonPropertyName("UF")]
    public string UF { get; set; }
}
