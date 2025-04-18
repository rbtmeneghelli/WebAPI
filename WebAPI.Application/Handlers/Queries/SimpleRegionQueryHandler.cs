using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;
using FastPackForShare;
using FastPackForShare.Constants;
using FastPackForShare.SimpleMediator;

namespace WebAPI.Application.Handlers.Queries;

public sealed class SimpleRegionQueryHandler :
IRequestHandler<SimpleRegionQueryFilterRequest, CustomResponseModel>,
IRequestHandler<SimpleRegionQueryByIdRequest, CustomResponseModel>
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;

    public SimpleRegionQueryHandler(
        IRegionRepository iRegionRepository,
        IMapperService iMapperService)
    {
        _iRegionRepository = iRegionRepository;
        _iMapperService = iMapperService;
    }

    public async Task<CustomResponseModel> Handle(SimpleRegionQueryFilterRequest request, CancellationToken cancellationToken)
    {
        List<RegionQueryFilterResponse> regionQueryFilterResponses = new();
        var result = _iRegionRepository.GetAll();
        var data = _iMapperService.ApplyMapToEntity<IEnumerable<Region>, IEnumerable<RegionQueryFilterResponse>>(result);
        return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
    }

    public async Task<CustomResponseModel> Handle(SimpleRegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        var result = _iRegionRepository.GetById(request.Id.Value);
        var data = _iMapperService.ApplyMapToEntity<Region, RegionQueryByIdResponse>(result);
        return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
    }
}