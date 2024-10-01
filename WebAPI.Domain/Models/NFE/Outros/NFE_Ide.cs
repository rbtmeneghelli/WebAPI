using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Ide
{
    [JsonPropertyName("cUF")]
    public string CodigoUF { get; set; }
    [JsonPropertyName("cNF")]
    public string codigoNF { get; set; }
    [JsonPropertyName("natOp")]
    public string NatOp { get; set; }
    [JsonPropertyName("indPag")]
    public string IndPag { get; set; }
    [JsonPropertyName("mod")]
    public string Mod { get; set; }
    [JsonPropertyName("serie")]
    public string Serie { get; set; }
    [JsonPropertyName("nNF")]
    public string NumeroNF { get; set; }
    [JsonPropertyName("dEmi")]
    public string DataEmissao { get; set; }
    [JsonPropertyName("dSaiEnt")]
    public string DSaiEnt { get; set; }
    [JsonPropertyName("tpNF")]
    public string TipoNF { get; set; }
    [JsonPropertyName("cMunFG")]
    public string CodigoMunicipioFG { get; set; }
    [JsonPropertyName("tpImp")]
    public string TipoImp { get; set; }
    [JsonPropertyName("tpEmis")]
    public string TipoEmis { get; set; }
    [JsonPropertyName("cDV")]
    public string CodigoDV { get; set; }
    [JsonPropertyName("tpAmb")]
    public string TipoAmb { get; set; }
    [JsonPropertyName("finNFe")]
    public string FinNFe { get; set; }
    [JsonPropertyName("procEmi")]
    public string ProcEmi { get; set; }
    [JsonPropertyName("verProc")]
    public string VerProc { get; set; }
}
