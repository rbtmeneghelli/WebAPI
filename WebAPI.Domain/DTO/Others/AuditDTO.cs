using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.Others;

public record AuditResponseDTO : BaseDTOModel
{
    public string TableName { get; set; }
    public string ActionName { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public DateTime? UpdateTime { get; set; }
    public override string ToString() => $"Tabela: {TableName}";
}

public record AuditRequestDTO : BaseDTOModel
{
    public string TableName { get; set; }
    public string ActionName { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public DateTime? UpdateTime { get; set; }
    public override string ToString() => $"Tabela: {TableName}";
}
