using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Delete.DeleteSale;

public class DeleteSaleCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}
