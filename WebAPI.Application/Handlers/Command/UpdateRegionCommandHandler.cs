using WebAPI.Domain.CQRS.Command;
using MediatR;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application.Handlers.Command;

public class UpdateRegionCommandHandler : GenericService, IRequestHandler<UpdateRegionCommandRequest, bool>
{
    private readonly IRegionRepository _regionRepository;

    public UpdateRegionCommandHandler(IRegionRepository regionRepository, INotificationMessageService notificationMessageService) : base(notificationMessageService)
    {
        _regionRepository = regionRepository;
    }

    public Task<bool> Handle(UpdateRegionCommandRequest request, CancellationToken cancellationToken)
    {
        var region = _regionRepository.GetById(request.Id.Value);

        if (region is not null)
        {
            region.Name = request.Name;
            region.Initials = request.Initials;
            _regionRepository.Update(region);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
