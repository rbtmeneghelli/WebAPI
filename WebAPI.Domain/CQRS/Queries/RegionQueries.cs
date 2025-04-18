using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;
using FastPackForShare;

namespace WebAPI.Domain.CQRS.Queries;

public class RegionQueryFilterRequest : RegionFilter, IRequest<CustomResponseModel>
{
}


public class RegionQueryFilterResponse : Region
{
}

public class RegionQueryByIdRequest : Region, IRequest<CustomResponseModel>
{
}

public class RegionQueryByIdResponse : Region
{
}


