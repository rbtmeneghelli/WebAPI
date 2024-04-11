using WebAPI.Domain.Entities;
using WebAPI.Domain.Filters;
using MediatR;

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

