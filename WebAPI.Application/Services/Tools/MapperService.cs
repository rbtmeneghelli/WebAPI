using AutoMapper;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public class MapperService : IMapperService
{
    private readonly IMapper _iMapperService;

    public MapperService(IMapper iMapperService)
    {
        _iMapperService = iMapperService;
    }

    public TDestination ApplyMapToEntity<TSource, TDestination>(TSource source)
    {
        return _iMapperService.Map<TDestination>(source);
    }
}
