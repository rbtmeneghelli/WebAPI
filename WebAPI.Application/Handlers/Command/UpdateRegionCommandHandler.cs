using WebAPI.Domain.CQRS.Command;
using MediatR;
using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application.Handlers.Command;

public class UpdateRegionCommandHandler : GenericService, IRequestHandler<UpdateRegionCommandRequest, bool>
{
    private readonly IRegionRepository _iRegionRepository;

    public UpdateRegionCommandHandler(IRegionRepository iRegionRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iRegionRepository = iRegionRepository;
    }

    public Task<bool> Handle(UpdateRegionCommandRequest request, CancellationToken cancellationToken)
    {
        var region = _iRegionRepository.GetById(request.Id.Value);

        if (region is not null)
        {
            region.Name = request.Name;
            region.Initials = request.Initials;
            _iRegionRepository.Update(region);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
