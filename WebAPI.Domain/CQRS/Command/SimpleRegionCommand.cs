using WebAPI.Domain.Entities.Others;
using FastPackForShare.SimpleMediator.Contracts;

namespace WebAPI.Domain.CQRS.Command;

public class SimpleCreateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}

public class SimpleUpdateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}
