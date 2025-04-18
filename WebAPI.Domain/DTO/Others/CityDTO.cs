using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.Others;

public record CityResponseDTO : BaseDTOModel
{
    [DisplayName("Código IBGE")]
    public long? IBGE { get; set; }

    [DisplayName("Municipio")]
    public string Name { get; set; }

    public long? IdState { get; set; }

    [DisplayName("Estado")]
    public string StateDesc { get; set; }

    [DisplayName("Ativo")]
    public string IsActiveDesc { get; set; }

    public override string ToString() => $"Municipio: {Name}";
}

public record CityRequestDTO : BaseDTOModel
{
    public long? IBGE { get; set; }

    public string Name { get; set; }

    public long? IdState { get; set; }

    public string StateDesc { get; set; }

    public override string ToString() => $"Municipio: {Name}";
}
