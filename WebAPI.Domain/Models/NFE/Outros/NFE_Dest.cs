using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Dest
{
    [JsonProperty("CNPJ")]
    public string Cnpj { get; set; }
    [JsonProperty("xNome")]
    public string Nome { get; set; }
    [JsonProperty("xLgr")]
    public string Logradouro { get; set; }
    [JsonProperty("nro")]
    public string Numero { get; set; }
    [JsonProperty("xCpl")]
    public string Complemento { get; set; }
    [JsonProperty("xBairro")]
    public string Bairro { get; set; }
    [JsonProperty("cMun")]
    public string CodMunicipio { get; set; }
    [JsonProperty("xMun")]
    public string Municipio { get; set; }
    [JsonProperty("UF")]
    public string UF { get; set; }
    [JsonProperty("CEP")]
    public string Cep { get; set; }
    [JsonProperty("cPais")]
    public string CodigoPais { get; set; }
    [JsonProperty("xPais")]
    public string Pais { get; set; }
    [JsonProperty("fone")]
    public string Telefone { get; set; }
    [JsonProperty("IE")]
    public string IE { get; set; }
}
