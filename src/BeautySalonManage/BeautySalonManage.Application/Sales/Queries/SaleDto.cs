using AutoMapper;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Sales.Queries;

public class SaleDto : IMapFrom<Sale>
{
    public long Id { get; set; }
    public DateTime DateSale { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public double Amount { get; set; }

    public IReadOnlyCollection<SaleDetailDto> Details { get; set; }
    public IReadOnlyCollection<SaleAdditionalDetailDto> AdditionalDetails { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Sale, SaleDto>()
            .ForMember(d => d.Details, opt => opt.MapFrom(s => s.SaleDetails))
            .ForMember(d => d.AdditionalDetails, opt => opt.MapFrom(s => s.SaleAdditionalDetails));
    }
}
