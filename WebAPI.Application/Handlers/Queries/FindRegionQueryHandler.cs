using WebAPI.Domain.CQRS.Command;
using MediatR;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application.Handlers.Queries;

public class FindRegionQueryFilterHandler : GenericService, IRequestHandler<RegionQueryFilterRequest, IEnumerable<Region>>
{
    private readonly IRegionRepository _regionRepository;

    public FindRegionQueryFilterHandler(IRegionRepository regionRepository, INotificationMessageService notificationMessageService) : base(notificationMessageService)
    {
        _regionRepository = regionRepository;
    }

    public Task<IEnumerable<Region>> Handle(RegionQueryFilterRequest request, CancellationToken cancellationToken)
    {
        List<RegionQueryFilterResponse> regionQueryFilterResponses = new();
        var result = _regionRepository.GetAll();
        //foreach (var item in result)
        //{
        //    regionQueryFilterResponses.Add(new RegionQueryFilterResponse()
        //    {
        //        Id = item.Id,
        //        CreatedTime = item.CreatedTime,
        //        Initials = item.Initials,
        //        IsActive = item.IsActive,
        //        Name = item.Name,
        //        UpdateTime = item.UpdateTime,
        //    });
        //}

        return Task.FromResult(result.AsEnumerable());
    }
}