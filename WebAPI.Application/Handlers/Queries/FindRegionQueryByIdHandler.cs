using MediatR;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;

namespace WebAPI.Application.Handlers.Queries;

public class FindRegionQueryByIdHandler : IRequestHandler<RegionQueryByIdRequest, Region>
{
    private readonly IRegionRepository _iRegionRepository;

    public FindRegionQueryByIdHandler(IRegionRepository iRegionRepository)
    {
        _iRegionRepository = iRegionRepository;
    }

    public Task<Region> Handle(RegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        var result = _iRegionRepository.GetById(request.Id.Value);
        return Task.FromResult(result);
    }
}