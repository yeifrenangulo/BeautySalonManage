using AutoMapper;
using BeautySalonManage.Application.Collaborators.Queries;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Services.Queries;

public class ServiceCollaboratorDto : IMapFrom<Service>, IMapFrom<CollaboratorService>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Price { get; set; }
    public IReadOnlyCollection<CollaboratorDto> Collaborators { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Service, ServiceCollaboratorDto>()
            .ForMember(d => d.Duration, opt => opt.MapFrom(s => TimeSpan.Parse(s.Duration)))
            .ForMember(d => d.Collaborators, opt => opt.MapFrom(s => s.CollaboratorServices.Select(x => x.Collaborator)));
    }
}
