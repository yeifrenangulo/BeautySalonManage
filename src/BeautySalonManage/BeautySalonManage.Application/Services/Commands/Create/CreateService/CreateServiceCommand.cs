using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Create.CreateService;

public class CreateServiceCommand : IRequest<Response<int>>, IMapFrom<Service>
{
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Duration { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
}