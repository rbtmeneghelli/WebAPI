using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_Ide
{
    [JsonProperty("cUF")]
    public string CodigoUF { get; set; }
    [JsonProperty("cNF")]
    public string codigoNF { get; set; }
    [JsonProperty("natOp")]
    public string NatOp { get; set; }
    [JsonProperty("indPag")]
    public string IndPag { get; set; }
    [JsonProperty("mod")]
    public string Mod { get; set; }
    [JsonProperty("serie")]
    public string Serie { get; set; }
    [JsonProperty("nNF")]
    public string NumeroNF { get; set; }
    [JsonProperty("dEmi")]
    public string DataEmissao { get; set; }
    [JsonProperty("dSaiEnt")]
    public string DSaiEnt { get; set; }
    [JsonProperty("tpNF")]
    public string TipoNF { get; set; }
    [JsonProperty("cMunFG")]
    public string CodigoMunicipioFG { get; set; }
    [JsonProperty("tpImp")]
    public string TipoImp { get; set; }
    [JsonProperty("tpEmis")]
    public string TipoEmis { get; set; }
    [JsonProperty("cDV")]
    public string CodigoDV { get; set; }
    [JsonProperty("tpAmb")]
    public string TipoAmb { get; set; }
    [JsonProperty("finNFe")]
    public string FinNFe { get; set; }
    [JsonProperty("procEmi")]
    public string ProcEmi { get; set; }
    [JsonProperty("verProc")]
    public string VerProc { get; set; }
}
