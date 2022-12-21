using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Features.Clients.Commands;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion

            #region DTOs
            CreateMap<Customer, CustomerDTO>();
            #endregion
        }
    }
}
