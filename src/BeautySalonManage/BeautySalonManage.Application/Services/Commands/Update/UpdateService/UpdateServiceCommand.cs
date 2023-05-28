using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Services.Commands.Update.UpdateService;

public class UpdateServiceCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Duration { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
}