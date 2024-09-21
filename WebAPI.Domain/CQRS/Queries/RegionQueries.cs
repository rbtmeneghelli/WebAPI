using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Command;

public class RegionQueryFilterRequest : RegionFilter, IRequest<IEnumerable<Region>>
{
}

public class RegionQueryByIdRequest : Region, IRequest<Region>
{
}

public class RegionQueryFilterResponse : Region
{
}

