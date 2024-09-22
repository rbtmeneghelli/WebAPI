using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public class ReadPropertyValueService<TSource, TDestination> : IReadPropertyValueGenericService<TSource,TDestination> where TSource : class where TDestination : class
{
    private readonly IReadPropertyValueGenericService<TSource, TDestination> _iReadPropertyValueGenericService;
    
    public ReadPropertyValueService(IReadPropertyValueGenericService<TSource, TDestination> iReadPropertyValueGenericService)
    {
        _iReadPropertyValueGenericService = iReadPropertyValueGenericService;
    }

    public TDestination TradeSpecialCharactersToStringFromObject(object obj)
    {
        return _iReadPropertyValueGenericService.TradeSpecialCharactersToStringFromObject(obj);
    }

    public TDestination TradeSpecialCharactersToStringFromList(object obj)
    {
        return _iReadPropertyValueGenericService.TradeSpecialCharactersToStringFromList(obj);
    }

    public void Dispose()
    {
        _iReadPropertyValueGenericService.Dispose();
    }
}
