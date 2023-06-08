using AutoMapper;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Turns.Queries;

public class TurnDto : IMapFrom<Turn>
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }

    public IReadOnlyCollection<TurnDetailDto> Details { get; set; }
    public IReadOnlyCollection<TurnAdditionalDetailDto> AdditionalDetails { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Turn, TurnDto>()
            .ForMember(d => d.StateName, opt => opt.MapFrom(s => s.States.Name))
            .ForMember(d => d.Details, opt => opt.MapFrom(s => s.TurnDetails))
            .ForMember(d => d.AdditionalDetails, opt => opt.MapFrom(s => s.TurnAdditionalDetails));
    }
}
