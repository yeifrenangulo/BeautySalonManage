using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetServiceById;

public class GetServiceByIdQuery : IRequest<Response<ServiceDto>>
{
    public int ServiceId { get; set; }
}