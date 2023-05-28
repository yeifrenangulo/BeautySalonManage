using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Services.Queries;

public class ServiceDto : IMapFrom<Service>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Duration { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
}
