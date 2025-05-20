using MediatR;
using WebAPI.Domain.DTO.Others;

namespace WebAPI.Domain.CQRS.Command;

public record CreateRegionCommandRequest : RegionCreateRequestDTO, IRequest<CustomResponseModel>
{
}

public record UpdateRegionCommandRequest : RegionUpdateRequestDTO, IRequest<CustomResponseModel>
{
}
