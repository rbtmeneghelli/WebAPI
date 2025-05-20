using MediatR;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;

namespace WebAPI.Domain.CQRS.Queries;

public record RegionQueryFilterRequest : IRequest<CustomResponseModel>
{
    public RegionFilter Filter { get; set; }
}


public record RegionQueryFilterResponse : RegionResponseDTO
{
}

public class RegionQueryByIdRequest : Region, IRequest<CustomResponseModel>
{
}

public record RegionQueryByIdResponse : RegionResponseDTO
{
}


