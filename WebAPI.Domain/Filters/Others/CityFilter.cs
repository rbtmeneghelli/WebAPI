using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record CityFilter : BaseFilterModel
{
    public string Name { get; set; }

    public long? IBGE { get; set; }

    public long? IdState { get; set; }
}
