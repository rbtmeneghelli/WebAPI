using MediatR;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;

namespace WebAPI.Application.Handlers.Queries;

public class FindRegionQueryFilterHandler : GenericService, IRequestHandler<RegionQueryFilterRequest, IEnumerable<RegionQueryFilterResponse>>
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;

    public FindRegionQueryFilterHandler(IRegionRepository iRegionRepository, INotificationMessageService iNotificationMessageService, IMapperService iMapperService) : base(iNotificationMessageService)
    {
        _iRegionRepository = iRegionRepository;
        _iMapperService = iMapperService;
    }

    public Task<IEnumerable<RegionQueryFilterResponse>> Handle(RegionQueryFilterRequest request, CancellationToken cancellationToken)
    {
        List<RegionQueryFilterResponse> regionQueryFilterResponses = new();
        var result = _iRegionRepository.GetAll();
        var data = _iMapperService.ApplyMapToEntity<IEnumerable<Region>, IEnumerable<RegionQueryFilterResponse>>(result);
        return Task.FromResult(data);
    }
}