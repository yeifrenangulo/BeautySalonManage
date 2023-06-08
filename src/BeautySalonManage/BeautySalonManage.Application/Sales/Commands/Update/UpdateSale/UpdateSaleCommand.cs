using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Sales.Queries;
using MediatR;

namespace BeautySalonManage.Application.Sales.Commands.Update.UpdateSale;

public class UpdateSaleCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public DateTime DateSale { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public double Amount { get; set; }
    public long? TurnId { get; set; }

    public List<SaleDetailDto> Details { get; set; }
    public List<SaleAdditionalDetailDto> AdditionalDetails { get; set; }
}
