namespace WebAPI.Domain.DTO.Others;

public record RegionCreateRequestDTO : GenericDTOModel
{
    [JsonPropertyName("Nome")]
    public string Name { get; set; }
    [JsonPropertyName("Sigla")]
    public string Initials { get; set; }
}

public record RegionUpdateRequestDTO : GenericDTOModel
{
    private long? _id;

    public long? Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = ((!value.HasValue) ? null : ((value > 0) ? value : null));
        }
    }

    [JsonPropertyName("Nome")]
    public string Name { get; set; }
    [JsonPropertyName("Sigla")]
    public string Initials { get; set; }
}

public record RegionResponseDTO : GenericDTOModel
{
    public string Name { get; set; }
    public string Initials { get; set; }
}