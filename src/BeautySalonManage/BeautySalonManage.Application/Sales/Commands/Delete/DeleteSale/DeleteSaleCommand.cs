using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Delete.DeleteSale;

public class DeleteSaleCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
}
