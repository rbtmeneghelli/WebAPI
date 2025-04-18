using FastPackForShare.Bases.Generics;

namespace WebAPI.Domain.DTO.Others;

public sealed record RegionResponseDTO : GenericDTOModel
{
    public string Name { get; set; }
    public string Initials { get; set; }
}
