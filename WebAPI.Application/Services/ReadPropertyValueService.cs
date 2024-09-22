using WebAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services
{
    public class ReadPropertyValueService<TSource, TDestination> : IReadPropertyValueGenericService<TSource,TDestination> where TSource : class where TDestination : class
    {
        private readonly IReadPropertyValueGenericService<TSource, TDestination> _readPropertyValueService;
        
        public ReadPropertyValueService(IReadPropertyValueGenericService<TSource, TDestination> readPropertyValueService)
        {
            _readPropertyValueService = readPropertyValueService;
        }

        public TDestination TradeSpecialCharactersToStringFromObject(object obj)
        {
            return _readPropertyValueService.TradeSpecialCharactersToStringFromObject(obj);
        }

        public TDestination TradeSpecialCharactersToStringFromList(object obj)
        {
            return _readPropertyValueService.TradeSpecialCharactersToStringFromList(obj);
        }

        public void Dispose()
        {
            _readPropertyValueService.Dispose();
        }
    }
}
