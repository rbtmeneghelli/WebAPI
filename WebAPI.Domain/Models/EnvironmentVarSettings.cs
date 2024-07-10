using Newtonsoft.Json;

namespace WebAPI.Domain.Models;

public sealed class EnvironmentVarSettings
{
    [JsonProperty("versaoSistema")]
    public string VersaoSistema { get; set; }
    [JsonProperty("habilitarValidacaoDuasEtapas")]
    public bool HabilitarValidacaoDuasEtapas { get; set; }
    [JsonProperty("gravarLogsErro")]
    public bool GravarLogsErro { get; set; }
    [JsonProperty("gravarLogsAuditoria")]
    public bool GravarLogsAuditoria { get; set; }
}

