using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public sealed record CityFilter : BaseFilterModel
{
    public long? Id { get; set; }

    public string Name { get; set; }

    public long? IBGE { get; set; }

    public long? IdState { get; set; }
}
