namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IMapperService
{
    TDestination ApplyMapToEntity<TSource, TDestination>(TSource source);
}
