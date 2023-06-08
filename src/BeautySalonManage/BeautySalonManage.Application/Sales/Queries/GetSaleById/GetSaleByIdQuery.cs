using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Sales.Queries.GetSaleById;

public class GetSaleByIdQuery : IRequest<Response<SaleDto>>
{
    public Guid Id { get; set; }
}
