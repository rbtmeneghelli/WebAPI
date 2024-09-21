using System.ComponentModel;
using WebAPI.Domain.EntitiesDTO.Generic;

namespace WebAPI.Domain.EntitiesDTO.Others;

public record StatesResponseDTO : GenericDTO
{
    [DisplayName("Sigla")]
    public string Initials { get; set; }

    [DisplayName("Estado")]
    public string Name { get; set; }

    public override string ToString() => $"Estado: {Name}";
}

public record StatesRequestDTO : GenericDTO
{
    [DisplayName("Sigla")]
    public string Initials { get; set; }

    [DisplayName("Estado")]
    public string Name { get; set; }

    public override string ToString() => $"Estado: {Name}";
}
