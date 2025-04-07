using AutoMapper;
using ProjectAccessManagement.Application.DTOs.App;
using ProjectAccessManagement.Application.DTOs.Automation;
using ProjectAccessManagement.Application.DTOs.BusinessArea;
using ProjectAccessManagement.Application.DTOs.Credential;
using ProjectAccessManagement.Application.DTOs.Module;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;

namespace ProjectAccessManagement.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Credential mappings
            CreateMap<Credential, CredentialOutputDto>().ReverseMap();
            CreateMap<Credential, NewCredentialDto>().ReverseMap();
            CreateMap<Credential, UpdateCredentialDto>().ReverseMap();
            CreateMap<Credential, UpdateModulesInCredentialDto>().ReverseMap();

            // Module mappings
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleSimpleDto>().ReverseMap();

            // Application mappings
            CreateMap<App, AppModulesDto>().ReverseMap();
            CreateMap<App, AppOutputDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.AppType.ToString()))
                .ForMember(dest => dest.AppModules, opt => opt.MapFrom(src => src.Modules));
            CreateMap<AppOutputDto, App>()
                .ForMember(dest => dest.AppType, opt => opt.MapFrom(src => Enum.Parse<AppType>(src.Type)))
                .ForMember(dest => dest.Modules, opt => opt.Ignore());
            CreateMap<App, AppSimpleDto>().ReverseMap();
            CreateMap<App, NewAppDto>().ReverseMap();

            // Automations mappings
            CreateMap<Automation, AutomationOutputDto>().ReverseMap();
            CreateMap<Automation, AutomationSimpleOutputDto>().ReverseMap();
            CreateMap<Automation, AutomationUpdateDto>().ReverseMap();
            CreateMap<Automation, NewAutomationDto>().ReverseMap();

            // Business Area mappings
            CreateMap<BusinessArea, BusinessAreaOutputDto>().ReverseMap();
            CreateMap<BusinessArea, NewBusinessAreaDto>().ReverseMap();
        }
    }
} 