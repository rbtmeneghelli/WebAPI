using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;
using FastPackForShare;

namespace WebAPI.Domain.CQRS.Queries;

public class RegionQueryFilterRequest : IRequest<CustomResponseModel>
{
    public RegionFilter Filter { get; set; }
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


