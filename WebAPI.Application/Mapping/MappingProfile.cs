using WebAPI.Domain.CQRS.Command;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequestDTO, User>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.GetId()))
            .ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.IsAuthenticated, act => act.MapFrom(src => src.IsAuthenticated))
            .ForMember(dest => dest.LastPassword, act => act.MapFrom(src => src.LastPassword.ApplyTrim()))
            .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login.ApplyTrim()))
            .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password.ApplyTrim()));

            CreateMap<User, UserResponseDTO>()
            .ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.IsAuthenticated, act => act.MapFrom(src => src.IsAuthenticated))
            .ForMember(dest => dest.LastPassword, act => act.MapFrom(src => src.LastPassword.ApplyTrim()))
            .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login.ApplyTrim()))
            .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password.ApplyTrim())).ReverseMap();

            CreateMap<Log, LogResponseDTO>()
            .ForMember(dest => dest.Class, act => act.MapFrom(src => src.Class.ApplyTrim()))
            .ForMember(dest => dest.Method, act => act.MapFrom(src => src.Method.ApplyTrim()))
            .ForMember(dest => dest.MessageError, act => act.MapFrom(src => src.MessageError))
            .ForMember(dest => dest.Object, act => act.MapFrom(src => src.Object))
            .ForMember(dest => dest.UpdateTime, act => act.MapFrom(src => src.UpdateTime))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<Audit, AuditResponseDTO>()
            .ForMember(dest => dest.TableName, act => act.MapFrom(src => src.TableName.ApplyTrim()))
            .ForMember(dest => dest.ActionName, act => act.MapFrom(src => src.ActionName.ApplyTrim()))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.KeyValues, act => act.MapFrom(src => src.KeyValues))
            .ForMember(dest => dest.NewValues, act => act.MapFrom(src => src.NewValues))
            .ForMember(dest => dest.OldValues, act => act.MapFrom(src => src.OldValues)).ReverseMap();

            CreateMap<UserResponseDTO, UserExcelDTO>().ReverseMap();

            CreateMap<Region, RegionQueryFilterResponse>().ReverseMap();
        }
    }
}