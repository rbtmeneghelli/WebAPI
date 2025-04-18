using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public sealed record StateFilter : BaseFilterModel
{
    public string Name { get; set; }
}
