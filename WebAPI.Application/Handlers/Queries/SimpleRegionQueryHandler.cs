using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;
using FastPackForShare;
using FastPackForShare.Constants;
using FastPackForShare.SimpleMediator;
using WebAPI.Domain.Constants;

namespace WebAPI.Application.Handlers.Queries;

public sealed class SimpleRegionQueryHandler :
IRequestHandler<SimpleRegionQueryFilterRequest, CustomResponseModel>,
IRequestHandler<SimpleRegionQueryByIdRequest, CustomResponseModel>
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;
    private readonly IRedisService _redisService;

    public SimpleRegionQueryHandler(
        IRegionRepository iRegionRepository,
        IMapperService iMapperService,
        IRedisService redisService)
    {
        _iRegionRepository = iRegionRepository;
        _iMapperService = iMapperService;
        _redisService = redisService;
    }

    public async Task<CustomResponseModel> Handle(SimpleRegionQueryFilterRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<SimpleRegionQueryFilterResponse> data = Enumerable.Empty<SimpleRegionQueryFilterResponse>();
        string cacheKey = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ALL}";
        var existCacheKey = await _redisService.GetDataString(cacheKey);

        if (!string.IsNullOrWhiteSpace(existCacheKey))
        {
            return new CustomResponseModel(
                ConstantHttpStatusCode.OK_CODE,
                await _redisService.GetDataObject<IEnumerable<SimpleRegionQueryFilterResponse>>(cacheKey)
            );
        }
        else
        {
            var result = _iRegionRepository.GetAll();
            data = _iMapperService.MapEntityToDTOList<IEnumerable<Region>, IEnumerable<SimpleRegionQueryFilterResponse>>(result);
            await _redisService.AddDataObject(cacheKey, data);
            return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
        }
    }

    public async Task<CustomResponseModel> Handle(SimpleRegionQueryByIdRequest request, CancellationToken cancellationToken)
    {
        SimpleRegionQueryByIdResponse data;
        string cacheKey = $"{nameof(Region)}_{FixConstants.CACHE_KEY_ID}";
        var existCacheKey = await _redisService.GetDataString(cacheKey);

        if (!string.IsNullOrWhiteSpace(existCacheKey))
        {
            return new CustomResponseModel(
                ConstantHttpStatusCode.OK_CODE,
                await _redisService.GetDataObject<SimpleRegionQueryByIdResponse>(cacheKey)
            );
        }
        else
        {
            var result = _iRegionRepository.GetById(request.Id.Value);
            data = _iMapperService.MapEntityToDTO<Region, SimpleRegionQueryByIdResponse>(result);
            await _redisService.AddDataObject(cacheKey, data);
            return new CustomResponseModel(ConstantHttpStatusCode.OK_CODE, data);
        }
    }
}