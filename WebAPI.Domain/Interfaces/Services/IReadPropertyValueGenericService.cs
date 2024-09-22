namespace WebAPI.Domain.Interfaces.Services;

public interface IReadPropertyValueGenericService<TSource, TDestination> : IDisposable where TSource : class where TDestination : class
{
    TDestination TradeSpecialCharactersToStringFromObject(object obj);
    TDestination TradeSpecialCharactersToStringFromList(object obj);
}
