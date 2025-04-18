using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public sealed record RegionFilter : BaseFilterModel
{
    public string Name { get; set; }
}
