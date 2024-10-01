using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Emit
{
    [JsonPropertyName("CNPJ")]
    public string Cnpj { get; set; }
    [JsonPropertyName("xNome")]
    public string Nome { get; set; }
    [JsonPropertyName("xFant")]
    public string Fantasia { get; set; }
    [JsonPropertyName("xLgr")]
    public string Logradouro { get; set; }
    [JsonPropertyName("nro")]
    public string numero { get; set; }
    [JsonPropertyName("xCpl")]
    public string Complemento { get; set; }
    [JsonPropertyName("xBairro")]
    public string Bairro { get; set; }
    [JsonPropertyName("cMun")]
    public string codigoMunicipio { get; set; }
    [JsonPropertyName("xMun")]
    public string Municipio { get; set; }
    [JsonPropertyName("UF")]
    public string UF { get; set; }
    [JsonPropertyName("CEP")]
    public string CEP { get; set; }
    [JsonPropertyName("cPais")]
    public string codigoPais { get; set; }
    [JsonPropertyName("xPais")]
    public string Pais { get; set; }
    [JsonPropertyName("fone")]
    public string Telefone { get; set; }
    [JsonPropertyName("IE")]
    public string IE { get; set; }
}
