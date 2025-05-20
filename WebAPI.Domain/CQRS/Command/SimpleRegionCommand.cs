using FastPackForShare.SimpleMediator.Contracts;
using WebAPI.Domain.DTO.Others;

namespace WebAPI.Domain.CQRS.Command;

public record SimpleCreateRegionCommandRequest : RegionCreateRequestDTO, IRequest<CustomResponseModel>
{
}

public record SimpleUpdateRegionCommandRequest : RegionUpdateRequestDTO, IRequest<CustomResponseModel>
{
}
