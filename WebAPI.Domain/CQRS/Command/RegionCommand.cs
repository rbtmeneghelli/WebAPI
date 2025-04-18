using MediatR;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.CQRS.Command;

public class CreateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}

public class UpdateRegionCommandRequest : Region, IRequest<CustomResponseModel>
{
}
