using WebAPI.Domain.Entities;
using MediatR;

namespace WebAPI.Domain.CQRS.Command;

public sealed class CreateRegionCommandRequest : Region, IRequest<bool>
{
}

public sealed class UpdateRegionCommandRequest : Region, IRequest<bool>
{
}
