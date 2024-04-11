using WebAPI.Domain.Generic;
using System.ComponentModel;

namespace WebAPI.Domain.DTO;

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
