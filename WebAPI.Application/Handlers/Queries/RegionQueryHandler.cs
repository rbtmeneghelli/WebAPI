using MediatR;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;
using FastPackForShare;
using FastPackForShare.Constants;
using Microsoft.Azure.Amqp.Framing;
using WebAPI.Domain.Constants;

namespace WebAPI.Application.Handlers.Queries;

public sealed class RegionQueryHandler :
IRequestHandler<RegionQueryFilterRequest, CustomResponseModel>,
IRequestHandler<RegionQueryByIdRequest, CustomResponseModel>
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;
    private readonly IRedisService _redisService;

    public RegionQueryHandler(
        IRegionRepository iRegionRepository,
        IMapperService iMapperService,
        IRedisService redisService)
    {
        _iRegionRepository = iRegionRepository;
        _iMapperService = iMapperService;
        _redisService = redisService;
    }

    public async Task<CustomResponseModel> Handle(RegionQueryFilterRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<RegionQueryFilterResponse> data = Enumerable.Empty<RegionQueryFilterResponse>();
        string cacheKey = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ALL}";
        var existCacheKey = await _redisService.GetDataString(cacheKey);

        if (!string.IsNullOrWhiteSpace(existCacheKey))
        {
            return new CustomResponseModel(
                ConstantHttpStatusCode.OK_CODE,
                await _redisService.GetDataObject<IEnumerable<RegionQueryFilterResponse>>(cacheKey)
            );
        }
        else
        {
            var result = _iRegionRepository.GetAll();
            data = _iMapperService.ApplyMapToEntity<IEnumerable<Region>, IEnumerable<RegionQueryFilterResponse>>(result);
            await _redisService.AddDataObject(cacheKey, data);
            return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
        }
    }

    public async Task<CustomResponseModel> Handle(RegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        RegionQueryByIdResponse data;
        string cacheKey = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ID}";
        var existCacheKey = await _redisService.GetDataString(cacheKey);

        if (!string.IsNullOrWhiteSpace(existCacheKey))
        {
            return new CustomResponseModel(
                ConstantHttpStatusCode.OK_CODE,
                await _redisService.GetDataObject<Region>(cacheKey)
            );
        }
        else
        {
            var result = _iRegionRepository.GetById(request.Id.Value);
            data = _iMapperService.ApplyMapToEntity<Region, RegionQueryByIdResponse>(result);
            await _redisService.AddDataObject(cacheKey, data);
            return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
        }
    }
}