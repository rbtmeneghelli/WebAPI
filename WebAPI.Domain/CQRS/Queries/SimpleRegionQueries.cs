using FastPackForShare.SimpleMediator.Contracts;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;

namespace WebAPI.Domain.CQRS.Queries;

public class SimpleRegionQueryFilterRequest : IRequest<CustomResponseModel>
{
    public RegionFilter Filter { get; set; }
}


public class SimpleRegionQueryFilterResponse : Region
{
}

public class SimpleRegionQueryByIdRequest : Region, IRequest<CustomResponseModel>
{
}

public class SimpleRegionQueryByIdResponse : Region
{
}
