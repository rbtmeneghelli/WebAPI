using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.Others;

public record StatesResponseDTO : BaseDTOModel
{
    [DisplayName("Sigla")]
    public string Initials { get; set; }

    [DisplayName("Estado")]
    public string Name { get; set; }

    public override string ToString() => $"Estado: {Name}";
}

public record StatesRequestDTO : BaseDTOModel
{
    [DisplayName("Sigla")]
    public string Initials { get; set; }

    [DisplayName("Estado")]
    public string Name { get; set; }

    public override string ToString() => $"Estado: {Name}";
}
