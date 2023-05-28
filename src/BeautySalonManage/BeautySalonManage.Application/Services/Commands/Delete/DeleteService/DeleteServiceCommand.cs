using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Delete.DeleteService;

public class DeleteServiceCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}