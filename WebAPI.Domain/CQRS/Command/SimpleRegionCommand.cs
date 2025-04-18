using FastPackForShare;
using FastPackForShare.SimpleMediator.Contracts;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Command;

public sealed class SimpleCreateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}

public sealed class SimpleUpdateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}
