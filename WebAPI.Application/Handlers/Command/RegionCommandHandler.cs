using WebAPI.Domain.CQRS.Command;
using MediatR;
using WebAPI.Domain.Entities.Others;
using FastPackForShare;
using WebAPI.Domain.Interfaces.Services;
using FastPackForShare.Constants;
using WebAPI.Domain.Constants;

namespace WebAPI.Application.Handlers.Command;

public sealed class RegionCommandHandler :
IRequestHandler<CreateRegionCommandRequest, CustomResponseModel>,
IRequestHandler<UpdateRegionCommandRequest, CustomResponseModel>
{
    private readonly IRegionService _iRegionService;
    private readonly IMapperService _iMapperService;
    private readonly IRedisService _redisService;

    private string cacheKeyId = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ID}";
    private string cacheKeyAll = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ALL}";

    public RegionCommandHandler(IRegionService iRegionService, IMapperService iMapperService, IRedisService redisService)
    {
        _iRegionService = iRegionService;
        _iMapperService = iMapperService;
        _redisService = redisService;
    }

    public async Task<CustomResponseModel> Handle(CreateRegionCommandRequest request, CancellationToken cancellationToken)
    {
        var region = _iMapperService.ApplyMapToEntity<CreateRegionCommandRequest, Region>(request);

        await _iRegionService.CreateRegion(region);
        await _redisService.RemoveData(cacheKeyId);

        return new CustomResponseModel(ConstantHttpStatusCode.CREATE_CODE);
    }

    public async Task<CustomResponseModel> Handle(UpdateRegionCommandRequest request, CancellationToken cancellationToken)
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
