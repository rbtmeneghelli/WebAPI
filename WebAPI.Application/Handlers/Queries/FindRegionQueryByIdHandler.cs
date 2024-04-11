using WebAPI.Domain.CQRS.Command;
using MediatR;
using System.Threading;

namespace WebAPI.Application.Handlers.Queries;

public class FindRegionQueryByIdHandler : IRequestHandler<RegionQueryByIdRequest, Region>
{
    private readonly IRegionRepository _regionRepository;

    public FindRegionQueryByIdHandler(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public Task<Region> Handle(RegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        var result = _regionRepository.GetById(request.Id.Value);
        return Task.FromResult(result);
    }
}