using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record RegionFilter : BaseFilterModel
{
    public string Name { get; set; }
}
