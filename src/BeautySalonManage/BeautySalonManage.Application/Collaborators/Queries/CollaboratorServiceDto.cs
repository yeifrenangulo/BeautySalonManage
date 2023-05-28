using AutoMapper;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Services.Queries;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Collaborators.Queries;

public class CollaboratorServiceDto : IMapFrom<Collaborator>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NameContact { get; set; }
    public string PhoneContact { get; set; }
    public int GenderId { get; set; }
    public string GenderDescription { get; set; }
    public IReadOnlyCollection<ServicePercentageDto> Services { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Collaborator, CollaboratorServiceDto>()
            .ForMember(d => d.Services, opt => opt.MapFrom(s => s.CollaboratorServices)); ;
    }
}
