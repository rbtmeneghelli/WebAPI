using WebAPI.Domain.Generic;

namespace WebAPI.Domain.EntitiesDTO;

public record LogResponseDTO : GenericDTO
{
    public string Class { get; set; }
    public string Method { get; set; }
    public string MessageError { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Object { get; set; }
    public override string ToString() => $"Classe: {Class}";
}

public record LogRequestDTO : GenericDTO
{
    public string Class { get; set; }
    public string Method { get; set; }
    public string MessageError { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Object { get; set; }
    public override string ToString() => $"Estado: {Class}";
}
