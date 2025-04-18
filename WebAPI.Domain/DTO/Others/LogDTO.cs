using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.Others;

public record LogResponseDTO : BaseDTOModel
{
    public string Class { get; set; }
    public string Method { get; set; }
    public string MessageError { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Object { get; set; }
    public override string ToString() => $"Classe: {Class}";
}

public record LogRequestDTO : BaseDTOModel
{
    public string Class { get; set; }
    public string Method { get; set; }
    public string MessageError { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Object { get; set; }
    public override string ToString() => $"Estado: {Class}";
}
