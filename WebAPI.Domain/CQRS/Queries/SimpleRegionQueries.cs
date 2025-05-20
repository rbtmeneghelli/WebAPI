using FastPackForShare.SimpleMediator.Contracts;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;

namespace WebAPI.Domain.CQRS.Queries;

public class SimpleRegionQueryFilterRequest : IRequest<CustomResponseModel>
{
    public RegionFilter Filter { get; set; }
}


public record SimpleRegionQueryFilterResponse : RegionResponseDTO
{
}

public class SimpleRegionQueryByIdRequest : Region, IRequest<CustomResponseModel>
{
}

public record SimpleRegionQueryByIdResponse : RegionResponseDTO
{
}
