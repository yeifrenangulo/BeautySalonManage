using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Sales.Queries.GetAllSales;

public class GetAllSalesQuery : RequestParameter, IRequest<PagedResponse<List<SaleDto>>>
{
}
