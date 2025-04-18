using FastPackForShare;
using MediatR;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Command;

public sealed class CreateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}

public sealed class UpdateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}
