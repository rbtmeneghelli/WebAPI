using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Queries;

public class RegionQueryFilterRequest : RegionFilter, IRequest<IEnumerable<RegionQueryFilterResponse>>
{
}


public class RegionQueryFilterResponse : Region
{
}

public class RegionQueryByIdRequest : Region, IRequest<RegionQueryByIdResponse>
{
}

public class RegionQueryByIdResponse : Region
{
}


