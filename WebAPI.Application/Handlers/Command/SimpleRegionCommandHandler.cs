using FastPackForShare.Constants;
using FastPackForShare;
using WebAPI.Domain.CQRS.Command;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Services;
using FastPackForShare.SimpleMediator;
using WebAPI.Domain.Constants;

namespace WebAPI.Application.Handlers.Command;

public sealed class SimpleRegionCommandHandler :
IRequestHandler<SimpleCreateRegionCommandRequest, CustomResponseModel>,
IRequestHandler<SimpleUpdateRegionCommandRequest, CustomResponseModel>
{
    private readonly IRegionService _iRegionService;
    private readonly IMapperService _iMapperService;
    private readonly IRedisService _redisService;

    private string cacheKeyId = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ID}";
    private string cacheKeyAll = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ALL}";

    public SimpleRegionCommandHandler(IRegionService iRegionService, IMapperService iMapperService)
    {
        _iRegionService = iRegionService;
        _iMapperService = iMapperService;
    }

    public async Task<CustomResponseModel> Handle(SimpleCreateRegionCommandRequest request, CancellationToken cancellationToken)
    {
        var region = _iMapperService.ApplyMapToEntity<SimpleCreateRegionCommandRequest, Region>(request);

        await _iRegionService.CreateRegion(region);
        await _redisService.RemoveData(cacheKeyId);

        return new CustomResponseModel(ConstantHttpStatusCode.CREATE_CODE);
    }

    public async Task<CustomResponseModel> Handle(SimpleUpdateRegionCommandRequest request, CancellationToken cancellationToken)
    {
        var region = _iRegionService.GetRegionById(request.Id.Value);

        if (region is not null)
        {
            region.Name = request.Name;
            region.Initials = request.Initials;
        }

        await _iRegionService.UpdateRegion(region);
        await _redisService.RemoveData(cacheKeyId);

        return new CustomResponseModel(ConstantHttpStatusCode.NO_CONTENT_CODE);
    }
}
