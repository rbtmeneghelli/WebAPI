using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Dest
{
    [JsonPropertyName("CNPJ")]
    public string Cnpj { get; set; }
    [JsonPropertyName("xNome")]
    public string Nome { get; set; }
    [JsonPropertyName("xLgr")]
    public string Logradouro { get; set; }
    [JsonPropertyName("nro")]
    public string Numero { get; set; }
    [JsonPropertyName("xCpl")]
    public string Complemento { get; set; }
    [JsonPropertyName("xBairro")]
    public string Bairro { get; set; }
    [JsonPropertyName("cMun")]
    public string CodMunicipio { get; set; }
    [JsonPropertyName("xMun")]
    public string Municipio { get; set; }
    [JsonPropertyName("UF")]
    public string UF { get; set; }
    [JsonPropertyName("CEP")]
    public string Cep { get; set; }
    [JsonPropertyName("cPais")]
    public string CodigoPais { get; set; }
    [JsonPropertyName("xPais")]
    public string Pais { get; set; }
    [JsonPropertyName("fone")]
    public string Telefone { get; set; }
    [JsonPropertyName("IE")]
    public string IE { get; set; }
}
