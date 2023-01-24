using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.DTOs.Turns;
using BeautySalonManage.Application.Features.Collaborators.Commands.Create;
using BeautySalonManage.Application.Features.Customers.Commands.Create;
using BeautySalonManage.Application.Features.Services.Commands.Create;
using BeautySalonManage.Application.Features.Turns.Commands.Create.Commands;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<CreateServiceCommand, Service>();

            CreateMap<CreateCollaboratorCommand, Collaborator>();

            CreateMap<CreateTurnCommand, Turn>()
                .ForMember(d => d.StartTime, o => o.MapFrom(x => TimeSpan.Parse(x.StartTime)))
                .ForMember(d => d.EndTime, o => o.MapFrom(x => TimeSpan.Parse(x.EndTime)));
            #endregion

            #region DTOs
            CreateMap<Customer, CustomerDTO>();

            CreateMap<Service, ServiceDTO>();

            CreateMap<CollaboratorService, ServicePercentageDTO>();

            CreateMap<Collaborator, CollaboratorDTO>()
                .ForMember(d => d.Services, o => o.MapFrom(x => x.CollaboratorServices));

            CreateMap<TurnDetail, TurnDetailDTO>();

            CreateMap<TurnAdditionalDetail, TurnAdditionalDetailDTO>();

            CreateMap<Turn, TurnDTO>()
                .ForMember(d => d.Details, o => o.MapFrom(x => x.TurnDetails))
                .ForMember(d => d.AdditionalDetails, o => o.MapFrom(x => x.TurnAdditionalDetails));
            #endregion
        }
    }
}
