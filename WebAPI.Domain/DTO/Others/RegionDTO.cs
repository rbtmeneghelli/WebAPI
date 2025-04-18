namespace WebAPI.Domain.DTO.Others;

public record RegionResponseDTO : GenericDTOModel
{
    public string Name { get; set; }
    public string Initials { get; set; }
}
