using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Queries;

public record RegionQueryFilterRequest : IRequest<CustomResponseModel>
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


