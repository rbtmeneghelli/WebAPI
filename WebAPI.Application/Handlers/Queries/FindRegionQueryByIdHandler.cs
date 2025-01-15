using MediatR;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Handlers.Queries;

public class FindRegionQueryByIdHandler : IRequestHandler<RegionQueryByIdRequest, RegionQueryByIdResponse>
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;

    public FindRegionQueryByIdHandler(IRegionRepository iRegionRepository)
    {
        _iRegionRepository = iRegionRepository;
    }

    public Task<RegionQueryByIdResponse> Handle(RegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        var result = _iRegionRepository.GetById(request.Id.Value);
        var data = _iMapperService.ApplyMapToEntity<Region, RegionQueryByIdResponse>(result);
        return Task.FromResult(data);
    }
}